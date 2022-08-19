using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class CharacterIcon : MonoBehaviour
{
    [SerializeField] RectTransform RT;

    [SerializeField] Image Child;

    [SerializeField] TMP_Text choice1;

    [SerializeField] TMP_Text choice2;

    [SerializeField] TMP_Text characterName;

    [SerializeField] TMP_Text characterQuote;

    [SerializeField] TMP_Text dayInfo;

    [SerializeField] TMP_Text yearInfo;

    [SerializeField] Image fillPlant;

    [SerializeField] Image fillHuman;

    [SerializeField] Image fillGun;

    [SerializeField] Image fillMoney;

    [SerializeField] private float speed;

    private bool rightChoice = false;

    private bool leftChoice = false;

    private Animator anim;

    private float oppacity1;

    private float oppacity2;
    
    public ChoiceDataSO CDSO;

    void Start()
    {
        anim = GetComponent<Animator>();
        

    }

    // Update is called once per frame
    void Update()
    {
        
        if (RT.anchoredPosition.x > 240f && !rightChoice)
        {
            anim.SetInteger("IconAnim", 1);
            rightChoice = true;
            StartCoroutine("DeactiveAndReactivate");
           

        }
        if(RT.anchoredPosition.x < -240F && !leftChoice)
        {
            anim.SetInteger("IconAnim", 2);
            leftChoice = true;
            StartCoroutine("DeactiveAndReactivate");
        }
        oppacity1 = RT.anchoredPosition.x / -150;
        choice1.color = new Color(1f, 1f, 1f, oppacity1);

        oppacity2 = RT.anchoredPosition.x / 150;
        choice2.color = new Color(1f, 1f, 1f, oppacity2);


        

    }
    private void checkYear()
    {
        if ((int.Parse(dayInfo.GetParsedText()) / 365 >= 1 ))
        {
            Debug.Log("isdiir");
            CDSO.choiceLine.yearInfo = int.Parse(yearInfo.GetParsedText());
            yearInfo.SetText((CDSO.choiceLine.yearInfo + 1f).ToString());
            CDSO.choiceLine.dayInfo -= 365;
        }
    }
    private IEnumerator DeactiveAndReactivate()
    {
        yield return new WaitForSeconds(1.5f);
        anim.SetInteger("IconAnim", 3);
        CDSO.choiceLine.dayInfo = int.Parse(dayInfo.GetParsedText());
        checkYear();
        dayInfo.SetText((CDSO.choiceLine.dayInfo + Random.Range(2, 10)).ToString());

        
        


        if (rightChoice)
        {
            CDSO = CDSO.nextStates.nextState1;
            choice1.SetText(CDSO.nextStates.StateQuoteleft);
            choice2.SetText(CDSO.nextStates.StateQuoteright);
            characterName.SetText(CDSO.choiceLine.characterName);
            characterQuote.SetText(CDSO.choiceLine.characterQuote);
            Child.sprite = CDSO.choiceLine.characterIcon;

            switch (CDSO.choiceEffects.FilledPlant)
            {
                case 1:
                    StartCoroutine(littlePlantFilling(30f));
                    break;
            }

            rightChoice = false;
        }
        if (leftChoice)
        {
            CDSO = CDSO.nextStates.nextState2;
            choice1.SetText(CDSO.nextStates.StateQuoteleft);
            choice2.SetText(CDSO.nextStates.StateQuoteright);
            characterName.SetText(CDSO.choiceLine.characterName);
            characterQuote.SetText(CDSO.choiceLine.characterQuote);
            Child.sprite = CDSO.choiceLine.characterIcon;
            leftChoice = false;
        }
        


    }

    private IEnumerator littlePlantFilling(float duration)
    {
        for (float i = 0; i <= 0.3f; i += (speed * 0.01f))
        {
            fillPlant.fillAmount = i;
            fillPlant.color = Color.green;

            yield return new WaitForEndOfFrame();

        }

        fillPlant.fillAmount = 0.3f;
        fillPlant.color = Color.white;

    }
}
