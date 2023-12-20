using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NormalCollect : MonoBehaviour
{
    public GameObject player;
    public bool collecting = false;
    public float time;
    public GameObject collectText;
    private float plus; //¨C10¬í¥[1¦¸
    public int normalCollecting = 10;
    public float i;
    public Sound sound;

    [SerializeField] float CollectTime;
    [SerializeField] GameObject Bot;
    [SerializeField] GameObject BotModel;
    [SerializeField] Transform BotPos;
    [SerializeField] GameObject CollectBar;
    [SerializeField] GameObject CollectPrefab;
    private void Awake()
    {
        collectText.SetActive(false);
    }
    void Update()
    {
        if (player == null)
        {
            player = GameObject.Find("Player");
        }
        if (sound == null)
        {
            sound = player.GetComponent<Sound>();
        }
        Collect();
    }
    private void Collect()
    {
        plus = time / 10;
        if (collecting)
        {
            time += Time.deltaTime;
            CollectBar.GetComponent<Slider>().value = time;
            if (Mathf.Floor(plus) == i)
            {
                player.GetComponent<Player>().stuff[0] += normalCollecting;
                player.GetComponent<Player>().stuff[1] += normalCollecting;
                player.GetComponent<Player>().stuff[2] += normalCollecting;
                player.GetComponent<Player>().stuff[3] += normalCollecting;
                player.GetComponent<Player>().stuff[4] += normalCollecting;
                player.GetComponent<Player>().stuff[5] += normalCollecting;
                player.GetComponent<Player>().stuff[6] += normalCollecting;
                player.GetComponent<Player>().stuff[7] += normalCollecting;
                i++;
            }
            float amount = 0.05f;
            sound.addSound(amount);
            player.GetComponent<Player>().collectingPoint = this.gameObject;
        }
        if (Mathf.Floor(time) >= CollectTime)
        {
            collecting = false;
            Debug.Log("Collect End");
            time = 0;
            Destroy(Bot);
            Destroy(CollectBar);
            i = 1;
            player.GetComponent<Player>().collectingPoint = null;
        }
        CollectSlider();
    }
    private void CollectSlider()
    {
        if (CollectBar != null)
        {
            Vector3 worldToScreenPoint = Camera.main.WorldToScreenPoint(BotPos.position);
            CollectBar.transform.position = worldToScreenPoint + new Vector3(0f, 30f, 0f);
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !collecting)
        {
            collectText.SetActive(true);
            if (Input.GetKeyDown(KeyCode.F))
            {
                collectText.SetActive(false);
                collecting = true;

                Bot = Instantiate(BotModel);
                Bot.transform.position = BotPos.position;
                CollectBar = Instantiate(CollectPrefab);
                CollectBar.transform.SetParent(GameObject.Find("Canvas").transform);
                CollectBar.GetComponent<Slider>().maxValue = CollectTime;
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !collecting)
        {
            collectText.SetActive(false);
        }
    }
}
