using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RareCollect : MonoBehaviour
{
    public GameObject player;
    public bool collecting = false;
    public float time;
    public GameObject collectText;
    private float plus; //每1秒加1次音量
    public int rareCollecting = 5;
    public Sound sound;
    public float addsound;

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
        if (collecting)
        {
            time += Time.deltaTime;
            plus += Time.deltaTime;
            CollectBar.GetComponent<Slider>().value = time;
            if(plus >= 1)
            {
                float amount = addsound;
                sound.addSound(amount);
                plus = 0;
            }
            player.GetComponent<Player>().collectingPoint = this.gameObject;
        }
        if (Mathf.Floor(time) > CollectTime)
        {
            for (int i = 0; i < rareCollecting; i++)
            {
                int j = Random.Range(5, 7);
                player.GetComponent<Player>().stuff[j] += 1;
            }
            collecting = false;
            time = 0;
            plus = 0;
            Destroy(Bot);
            Destroy(CollectBar);
            player.GetComponent<Player>().collectingPoint = null;
            Destroy(this.gameObject);
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
