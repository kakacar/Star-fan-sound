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
            float amount = 0.1f;
            sound.addSound(amount);
            player.GetComponent<Player>().collectingPoint = this.gameObject;
        }
        if (Mathf.Floor(time) >= CollectTime)
        {
            collecting = false;
            Debug.Log("Collect End");
            time = 0;
            Destroy(Bot);
            i = 1;
            player.GetComponent<Player>().collectingPoint = null;
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
