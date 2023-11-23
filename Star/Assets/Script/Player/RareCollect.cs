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

    private float plus; //¨C10¬í¥[1¦¸
    public float rareCollecting = 5;
    public float i;

    [SerializeField] float CollectTime;
    [SerializeField] GameObject Bot;
    [SerializeField] GameObject BotModel;
    [SerializeField] GameObject BotPos;
    private void Awake()
    {
        player = GameObject.Find("Player");
        collectText.SetActive(false);

    }
    void Update()
    {
        plus = time / 10;
        if (collecting)
        {
            time += Time.deltaTime;
            if(Mathf.Floor(plus) == i)
            {
                player.GetComponent<Player>().rareCollected += rareCollecting;
                i++;
            }
        }
        if(Mathf.Floor(time) > CollectTime)
        {
            collecting = false;
            Debug.Log("Collect End");
            time = 0;
            Destroy(Bot);
            i = 1;
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

                Bot = Instantiate(BotModel, BotPos.transform);
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
