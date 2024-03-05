using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    [Header("Public Object")]
    public GameObject player;
    public GameObject body;
    public Animator animator;
    public CapsuleCollider PYcollider;
    public Rigidbody rb;
    public GameObject spawn;
    [SerializeField] Slider hpSlider;
    [SerializeField] public GameObject F;
    [SerializeField] public GameObject result;

    [Header("Public Value")]
    public float speed = 5f;
    [SerializeField] Vector3 jump = new Vector3(0.0f, 2.0f, 0.0f);
    public float jumpForce = 5.0f;
    //[SerializeField] bool isOnGround;
    public int jumpCount;
    [SerializeField] bool jumpPress;
    public float hp = 100;
    public bool CanAss;
    public bool StateSwitch;
    public bool firstToBase = true;
    public float OGSpeed;
    public int[] playerLevel;
    public int[] robotLevel;

    [Header("Ground Check")]
    [SerializeField] public float playerHeight;
    [SerializeField] LayerMask whatIsGround;
    [SerializeField] bool grounded;

    [Header("Collect")]
    [SerializeField] public float rareCollected;
    [SerializeField] public float normalCollected;
    [SerializeField] private Text[] normalText;

    [Header("Items")]
    [SerializeField] public int money;
    [SerializeField] public int[] stuff;
    [SerializeField] public int[] item;

    float xVelocity;
    float climbSpeed = 5f;
    bool HasPlayedDeadAni;
    bool UsingComputer;
    private string currentScene;
    private GameObject VCamera;
    public GameObject collectingPoint;
    public Next canvas;
    public bool respawn = false;
    
    public static Player morePlayer { get; private set; }

    public State StateType;
    public enum State
    {
        CanMove,
        Animation,
        Ladder,
        Duct
    }

    [SerializeField] private LiveOrDie CurrentState;
    private enum LiveOrDie
    {
        Alive,
        Dead
    }

    private void Awake()
    {
        if (morePlayer != null)
        {
            Destroy(this.gameObject);
            return;
        }
        morePlayer = this;
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        jumpCount = 2;
        rb = GetComponent<Rigidbody>();
        PYcollider = GetComponent<CapsuleCollider>();
        OGSpeed = speed;
        
        currentScene = SceneManager.GetActiveScene().name;
    }

    void Update()
    {
        Move();
        VCameraSet();
        Spawn();
        hpLeft();
        GroundCheck();
        CollectedCount();
    }

    private void VCameraSet()
    {
        if(VCamera == null)
        {
            VCamera = GameObject.Find("CM vcam1");
        }
        else if (VCamera.GetComponent<CinemachineVirtualCamera>().Follow == null)
        {
            VCamera.GetComponent<CinemachineVirtualCamera>().Follow = this.transform;
        }
    }
    private void Spawn()
    {
        if(spawn == null && SceneManager.GetActiveScene().name != ("Player&UI") && !respawn)
        {
            spawn = GameObject.Find("Spawn");
            player.transform.position = spawn.transform.position;
            player.transform.rotation = spawn.transform.rotation;
        }
        else if (spawn == null && SceneManager.GetActiveScene().name != ("Player&UI") && respawn)
        {
            spawn = GameObject.Find("Respawn");
            player.transform.position = spawn.transform.position;
            player.transform.rotation = spawn.transform.rotation;
            respawn = false;
        }
        if (currentScene == "MainMenu")
        {
            Destroy(this.gameObject);
        }
    }

    private void Move()
    {

        if (CurrentState == LiveOrDie.Alive && StateType != State.Animation)
        {
            xVelocity = Input.GetAxisRaw("Horizontal");
            rb.velocity = new Vector3(xVelocity * speed, rb.velocity.y, 0);

            if (xVelocity == 1 && StateType == State.CanMove || xVelocity == 1 && StateType == State.Duct)
            {
                animator.SetBool("Walking", true);
                player.gameObject.transform.rotation = Quaternion.Euler(0, 90, 0);
            }
            else if (xVelocity == -1 && StateType == State.CanMove|| xVelocity == -1 && StateType == State.Duct)
            {
                animator.SetBool("Walking", true);
                player.gameObject.transform.rotation = Quaternion.Euler(0, -90, 0);
            }
            else
            {
                animator.SetBool("Walking", false);
            }

            if (Input.GetKeyDown(KeyCode.Space) && jumpCount > 1 && grounded && StateType == State.CanMove)
            {
                animator.SetTrigger("1stJump");
                animator.SetBool("Jumping", true);
                jumpCount--;
            }
            if (Input.GetKeyDown(KeyCode.Space) && jumpCount > 0 && !grounded && StateType == State.CanMove)
            {
                animator.SetTrigger("2ndJump");
                animator.SetBool("Jumping", true);
                jumpCount--;
            }
            
        }
        else if (CurrentState == LiveOrDie.Alive && StateType == State.Animation)
        {
            rb.velocity = new Vector3(0, 0, 0);
        }
        else if(CurrentState == LiveOrDie.Dead)
        {
            rb.velocity = new Vector3(0, 0, 0);
        }

        
    }

    private void hpLeft()
    {
        hpSlider = GameObject.Find("Hp").GetComponent<Slider>();
        hpSlider.value = hp;
        if (hp <= 0)
        {
            hp = 0;
            CurrentState = LiveOrDie.Dead;
            respawn = true;
            if (!HasPlayedDeadAni)
            {
                animator.SetTrigger("Dead");
                HasPlayedDeadAni = true;
            }
            
        }
    }

    public void BeingHit(float Damage)
    {

        if (CurrentState == LiveOrDie.Alive)
        {
            hp = hp - Damage;
            if(StateType == State.CanMove)
            {
                animator.SetTrigger("BeingHit");
            }
            
        }

    }

    void OnTriggerStay(Collider other)
    {
        
        if (other.gameObject.CompareTag("CanDown"))
        {
            grounded = true;
            if (Input.GetKey("s"))
            {

                other.gameObject.GetComponent<StairDown>().TD = false;
            }
        }

        if (other.gameObject.CompareTag("Stair") && StateType != State.Animation)
        {
            grounded = true;
            if (Input.GetKey("w"))
            {
                //Animation
                StateType = State.Ladder;
                animator.SetBool("Walking", false);
                animator.SetBool("UsingLadder", true);
                animator.SetFloat("ClimbLadder", 1);
                player.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);

                //Move_And_Collider
                gameObject.GetComponent<Rigidbody>().useGravity = false;
                float verticalInput = Input.GetAxis("Vertical");
                Vector3 climbMovement = new Vector3(0f, verticalInput * climbSpeed * Time.deltaTime, 0f);
                transform.Translate(climbMovement);
                other.gameObject.GetComponent<Stair>().StairTD = false;

                Debug.Log("1 check");
            }
            else if (Input.GetKey("s"))
            {
                //Animation
                StateType = State.Ladder;
                animator.SetBool("Walking", false);
                animator.SetBool("UsingLadder", true);
                animator.SetFloat("ClimbLadder", 0);
                player.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);

                //Move_And_Collider
                float verticalInput = Input.GetAxis("Vertical");
                Vector3 climbMovement = new Vector3(0f, verticalInput * climbSpeed * Time.deltaTime, 0f);
                transform.Translate(climbMovement);
                other.gameObject.GetComponent<Stair>().StairTD = true;
                Debug.Log("2 check");
            }
            else if (StateType == State.Ladder)
            {
                
                other.gameObject.GetComponent<Stair>().StairTD = true;
                animator.SetFloat("ClimbLadder", 0.5f);
                Debug.Log("3 check");
            }
            
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            if (Input.GetKeyDown(KeyCode.Mouse1) && StateType == State.CanMove && CanAss == true && grounded)
            {
                //Debug.Log("ASS");
                StateType = State.Animation;
                StateSwitch = true;
                animator.SetTrigger("Assing");

                FieldOfView FOV = other.GetComponent<FieldOfView>();
                Enemy Ene = other.GetComponent<Enemy>();
                Animator EnemyAni = other.GetComponent<Animator>();
                
                FOV.BeStab = true;
                Ene.hp = 0;
                other.transform.position = transform.position;
                other.transform.rotation = transform.rotation;
                EnemyAni.SetTrigger("BeAssed");

            }
        }

        if (other.gameObject.CompareTag("Computer"))
        {
            F.SetActive(true);
            if (Input.GetKeyDown(KeyCode.F) && StateType == State.CanMove)
            {
                StateType = State.Animation;
                StateSwitch = true;
            }

            if (StateType == State.Animation && StateSwitch == true)
            {
                if (Vector3.Distance(transform.position, other.transform.position) > 0.1f)
                {
                    transform.position = Vector3.MoveTowards(transform.position, other.transform.position, speed * Time.deltaTime);
                    transform.LookAt(other.transform.position);
                    animator.SetBool("Walking", true);

                }
                else
                {
                    animator.SetBool("Walking", false);
                    player.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
                    if (!UsingComputer)
                    {
                        animator.SetTrigger("Computer");
                        UsingComputer = true;
                    }
                    //Debug.Log("This is Computer");
                }

            }

            if (StateType == State.Animation && StateSwitch == false)
            {

                UsingComputer = false;
                Vector3 Return = new Vector3(transform.position.x, transform.position.y, 0);
                if (transform.position != Return)
                {
                    animator.SetBool("Walking", true);
                    transform.position = Vector3.MoveTowards(transform.position, Return, speed * Time.deltaTime);
                    transform.LookAt(Return);

                }
                else
                {
                    animator.SetBool("Walking", false);
                    player.gameObject.transform.rotation = Quaternion.Euler(0, 90, 0);
                    StateType = State.CanMove;
                }

            }

        }

        if (other.gameObject.CompareTag("Duct"))
        {
            F.SetActive(true);
            Duct duct = other.GetComponent<Duct>();
            if (Input.GetKeyUp(KeyCode.F) && StateType == State.Duct)
            {
                
                //StateSwitch = true;
                StateType = State.Animation;
                transform.position = duct.Enter.transform.position;
                speed = 5f;

                animator.SetTrigger("DuctOut");
                duct.DuctOut();
                PYcollider.center = new Vector3(0.006f, 0.73f, 0.02f);
                PYcollider.height = 1.5f;
            }
            else if (Input.GetKeyUp(KeyCode.F) && StateType == State.CanMove && grounded)
            {
                
                    StateType = State.Animation;
                    speed = 3.5f;
                    //StateSwitch = true;

                    transform.position = duct.Leave.transform.position;
                    if (Vector3.Distance(transform.position.normalized, duct.Enter.transform.position.normalized) > 0)
                    {
                        animator.SetFloat("DuctDir", 1);
                    }
                    else
                    {
                        animator.SetFloat("DuctDir", 0);
                    }

                    animator.SetTrigger("DuctIn");
                    duct.DuctIn();
                    PYcollider.center = new Vector3(0.006f, 0.46f, 0.02f);
                    PYcollider.height = 0.9f;
                        

            }
            
        }
        if(other.tag == "Clear")
        {
            F.SetActive(true);
            if (Input.GetKeyUp(KeyCode.F))
            {
                if(SceneManager.GetActiveScene().name == "Base")
                {
                    canvas.NextStage();
                }
                else
                {
                    F.SetActive(false);
                    result.SetActive(true);
                }
            }
        }
        if(other.tag == "Back")
        {
            StateType = State.CanMove;
            gameObject.GetComponent<Rigidbody>().useGravity = true;
            SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
            SceneManager.LoadScene("Base", LoadSceneMode.Additive);
            animator.SetFloat("ClimbLadder", 0.5f);
            hp = 100;
            speed = OGSpeed;
            animator.SetBool("UsingLadder", false);
        }
        animator.SetBool("Jumping", false);
        animator.SetBool("InAir", false);
    }
    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Computer"))
        {
            F.SetActive(false);
        }
        if (other.gameObject.CompareTag("Duct"))
        {
            F.SetActive(false);
        }
        if (other.gameObject.CompareTag("CanDown"))
        {

            other.gameObject.GetComponent<StairDown>().TD = true;
        }
        if (other.gameObject.CompareTag("Stair"))
        {
            StateType = State.CanMove;
            other.gameObject.GetComponent<Stair>().StairTD = true;
            gameObject.GetComponent<Rigidbody>().useGravity = true;
            animator.SetBool("UsingLadder", false);
            animator.SetFloat("ClimbLadder", 0.5f);
            Debug.Log("5 check");
        }
        if (other.tag == "Clear")
        {
            F.SetActive(false);
        }
    }
    public void Jump()
    {
        jumpPress = true;
        rb.AddForce(jump * jumpForce, ForceMode.Impulse);

        if (jumpPress && grounded)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, 0);
            jumpPress = false;
        }
        else if (jumpPress && jumpCount >= 0 && !grounded)
        {
            //Vector3 TndJump = new Vector3(5f, 0.0f, 0.0f);
            //rb.AddForce(TndJump * 2.5f, ForceMode.Impulse);
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, 0);
            jumpPress = false;
        }
    }

    public void GroundCheck()
    {
        // ground check
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f, whatIsGround);

        if (!jumpPress && !grounded)
        {
            animator.SetBool("InAir", true);
        }
        else
        {
            animator.SetBool("InAir", false);         
            
        }
    }

    public void ResetJump()
    {
        if (jumpCount < 2)
        {
            jumpCount = 2;
        }
    }

    public void Dead()
    {
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
        SceneManager.LoadScene("Base", LoadSceneMode.Additive);
        hp = 100;
        speed = OGSpeed;
        CurrentState = LiveOrDie.Alive;
        HasPlayedDeadAni = false;
        animator.Rebind();
    }
    private void CollectedCount()
    {
        normalText[0].text = "電路板" + "\n" + "：" + stuff[0];
        normalText[1].text = "貴金屬" + "\n" + "：" + stuff[1];
        normalText[2].text = "能源金屬" + "\n" + "：" + stuff[2];
        normalText[3].text = "合成液" + "\n" + "：" + stuff[3];
        normalText[4].text = "生物組織" + "\n" + "：" + stuff[4];
        normalText[5].text = "生物DNA" + "\n" + "：" + stuff[5];
        normalText[6].text = "複合金屬" + "\n" + "：" + stuff[6];
        normalText[7].text = "能量精華" + "\n" + "：" + stuff[7];
    }
    public void LoadData(GameData data)
    {
        data.money = money;
        data.rareCollected = rareCollected;
        data.normalCollected = normalCollected;
    }
    public void SaveData(GameData data)
    {
        money = data.money;
        rareCollected = data.rareCollected;
        normalCollected = data.normalCollected;
    }
}