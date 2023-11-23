using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisableSoundSkill : MonoBehaviour
{
    private float t;
    private bool canUse;
    [SerializeField] GameObject skillUI;
    public bool isUsingSkill;
    public float skillDuration;
    [SerializeField] GameObject skillUsingIcon;
    private void Start()
    {
        if (skillUI == null)
        {
            skillUI = GameObject.Find("SkillUI");
        }

        if (skillUsingIcon == null)
        {
            skillUsingIcon = GameObject.Find("skillUsingIcon");
        }
        
        
    }
    void Update()
    {
        if(skillUI == null)
        {
            skillUI = GameObject.Find("SkillUI");
            
        }
        if (skillUsingIcon == null)
        {
            
            skillUsingIcon = GameObject.Find("skillUsingIcon");
            skillUsingIcon.SetActive(false);
        }

        CD();
        if (Input.GetKeyDown(KeyCode.K) && !isUsingSkill && canUse)
        {
            StartCoroutine(UseingSkill());
            t = 10f;
        }
    }
    IEnumerator UseingSkill()
    {
        isUsingSkill = true;
        GameObject.Find("Player").GetComponent<Sound>().currentSound = 0;
        skillUsingIcon.SetActive(true);
        yield return new WaitForSeconds(skillDuration);
        skillUsingIcon.SetActive(false);
        isUsingSkill = false;
    }
    public void CD()
    {
        t -= Time.deltaTime;
        if (t <= 0)
        {
            canUse = true;
            skillUI.GetComponent<CanvasGroup>().alpha = 1;
        }
        else
        {
            canUse = false;
            skillUI.GetComponent<CanvasGroup>().alpha = 0.5f;
        }
    }
}
