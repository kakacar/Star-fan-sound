
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    [Header("Object")]
    public GameObject playerRef;
    public LayerMask targetMask;
    public LayerMask obstructionMask;
    [SerializeField] public Light HeadLt;
    [SerializeField] private Transform[] PatrolPoints;
    [SerializeField] private int PDestination;
    [SerializeField] private GameObject Eye;

    [Header("Value")]
    public float radius;
    [Range(0,360)]
    public float angle;

    public bool canSeePlayer;
    public bool HasRoll;

    public float lostChase;
    public float lostPlayer;
    public float distanceToTarget;
    public bool BeStab;

    public ActionState ActState;

    private float RState;
    private Collider[] rangeChecks;
    private float StayTimer = 0;
    [SerializeField] Enemy Enemy;
    //public bool stop = true;

    public enum ActionState
    {
        Standy,
        Patrol,
        CloseCombat,
        LongRangeAttack,
        Stun
    }

    private void Start()
    {
        playerRef = GameObject.FindGameObjectWithTag("Player");
        //StartCoroutine(FOVRoutine());
        ActState = ActionState.Standy;
        lostPlayer = lostChase;
        HeadLt.color = new Color(0f, 176f, 255f);
    }
    public void FieldOfViewCheck()
    {
        rangeChecks = Physics.OverlapSphere(Eye.transform.position, float.PositiveInfinity, targetMask);

        if (rangeChecks.Length != 0)
        {
            Transform target = rangeChecks[0].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            if (Vector3.Angle(Eye.transform.forward, directionToTarget) < 1)
            {
                distanceToTarget = Vector3.Distance(transform.position, target.position);

                if (!Physics.Raycast(Eye.transform.position, directionToTarget, distanceToTarget, obstructionMask))
                {
                    canSeePlayer = true;
                    HeadLt.color = new Color(255f, 0f, 0f);
                    lostPlayer = lostChase;
                    //Debug.Log("CanSeePlayer");
                }
                else
                {
                    //Debug.Log("CantSeePlayer");
                    StopChase();
                }
                //Debug.Log(Vector3.Angle(Eye.transform.forward, directionToTarget));
            }
            else
            {
                //Debug.Log("CantSeePlayer1");
                StopChase();
            }
        }
        else if (canSeePlayer)
        {
            //Debug.Log("CantSeePlayer2");
            StopChase();
        }
        
    }
    void Update()
    {
        if(Enemy.enemyDead == false)
        {
            if (!BeStab)
            {
                Action();
            }
        }
    }

    public void Action()
    {
        Vector3 playerPosition = new Vector3(playerRef.transform.position.x, transform.position.y, 0);

        if (!canSeePlayer)
        {
            if (PDestination == 0)
            {
                
                ActState = ActionState.Patrol;
                transform.position = Vector3.MoveTowards(transform.position, PatrolPoints[0].position, 1.5f * Time.deltaTime);

                if (Vector3.Distance(transform.position, PatrolPoints[0].position) < 0.2f)
                {
                    ActState = ActionState.Standy;
                    StayTimer += Time.deltaTime;
                    
                    if (StayTimer > 2)
                    {
                        PDestination = 1;
                        Vector3 Direction = PatrolPoints[PDestination].position - transform.position;
                        Quaternion rotation = Quaternion.LookRotation(Direction);
                        transform.rotation = rotation;
                        //transform.rotation = Quaternion.Euler(0, 90, 0);
                        StayTimer = 0;
                    }
                    
                }
            }

            if (PDestination == 1)
            {
                ActState = ActionState.Patrol;
                transform.position = Vector3.MoveTowards(transform.position, PatrolPoints[1].position, 1.5f * Time.deltaTime);

                if (Vector3.Distance(transform.position, PatrolPoints[1].position) < 0.2f)
                {
                    ActState = ActionState.Standy;
                    StayTimer += Time.deltaTime;

                    if (StayTimer > 2)
                    {
                        PDestination = 0;
                        Vector3 Direction = PatrolPoints[PDestination].position - transform.position;
                        Quaternion rotation = Quaternion.LookRotation(Direction);
                        transform.rotation = rotation;
                        //transform.rotation = Quaternion.Euler(0, -90, 0);
                        StayTimer = 0;
                    }
                    
                }
            }
        }

        if(distanceToTarget > 7f && HasRoll == false && canSeePlayer)
        {
            RState = Random.Range(1, 10);
            HasRoll = true;
        }
        else if(distanceToTarget <= 7f && HasRoll == false && canSeePlayer)
        {
            RState = Random.Range(1, 3);
            HasRoll = true;
        }

        if(HasRoll == true)
        {
            if(RState > 3)
            {
                ActState = ActionState.LongRangeAttack;
                
            }
            else
            {
                if(canSeePlayer && ActState !=ActionState.Stun)
                {
                    if (playerRef.transform.position.x > transform.position.x && ActState != ActionState.CloseCombat)
                    {
                        transform.rotation = Quaternion.Euler(0, 90, 0);
                    }
                    else if (playerRef.transform.position.x < transform.position.x && ActState != ActionState.CloseCombat)
                    {
                        transform.rotation = Quaternion.Euler(0, -90, 0);
                    }

                    if (distanceToTarget > 1.4f)
                    {
                        ActState = ActionState.Patrol;

                        if(ActState == ActionState.Patrol)
                        {
                            transform.position = Vector3.MoveTowards(transform.position, playerPosition, 1.5f * Time.deltaTime);
                        }
                        
                        
                    }
                    else
                    {
                        ActState = ActionState.CloseCombat;

                    }

                }
                
            }

        }
        
    }

    public void StopChase()
    {
        if (canSeePlayer)
        {
            lostPlayer -= Time.deltaTime;
            if (lostPlayer < 0 && ActState!=ActionState.LongRangeAttack)
            {
                canSeePlayer = false;
                HasRoll = false;
                ActState = ActionState.Standy;
                lostPlayer = lostChase;
                HeadLt.color = new Color(0f, 176f, 255f);

                if(Vector3.Distance(transform.position, PatrolPoints[0].position) < Vector3.Distance(transform.position, PatrolPoints[1].position))
                {
                    PDestination = 0;
                    Vector3 Direction = PatrolPoints[PDestination].position - transform.position;
                    Quaternion rotation = Quaternion.LookRotation(Direction);
                    transform.rotation = rotation;
                    
                }
                else if((Vector3.Distance(transform.position, PatrolPoints[0].position) > Vector3.Distance(transform.position, PatrolPoints[1].position)))
                {
                    
                    PDestination = 1;
                    Vector3 Direction = PatrolPoints[PDestination].position - transform.position;
                    Quaternion rotation = Quaternion.LookRotation(Direction);
                    transform.rotation = rotation;
                }
                else
                {
                    PDestination = Random.Range(0,1);
                }

            }

        }
        
    }

}
