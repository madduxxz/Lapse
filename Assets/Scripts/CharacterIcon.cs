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

    [SerializeField] ChoiceDataSO Death;

    private bool rightChoice = false;

    private bool leftChoice = false;

    private Animator anim;

    private float oppacity1;

    private float oppacity2;
    
    public ChoiceDataSO CDSO;

    private float currentFilledPlant = 0;
    private float currentFilledHuman = 0;
    private float currentFilledGun = 0;
    private float currentFilledMoney = 0;

    void Start()
    {
        anim = GetComponent<Animator>();

    }

    
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
        checkDeath();
        dayInfo.SetText((CDSO.choiceLine.dayInfo + Random.Range(2, 10)).ToString());

        if (CDSO == Death)
        {
            
            SettingsPanelView.Current.DeathCourtine();
            
        }
        


        if (rightChoice)
        {
            CDSO = CDSO.nextStates.nextState2;
            choice1.SetText(CDSO.nextStates.StateQuoteleft);
            choice2.SetText(CDSO.nextStates.StateQuoteright);
            characterName.SetText(CDSO.choiceLine.characterName);
            characterQuote.SetText(CDSO.choiceLine.characterQuote);
            Child.sprite = CDSO.choiceLine.characterIcon;
            rightChoice = false;
        }
        if (leftChoice)
        {
            CDSO = CDSO.nextStates.nextState1;
            choice1.SetText(CDSO.nextStates.StateQuoteleft);
            choice2.SetText(CDSO.nextStates.StateQuoteright);
            characterName.SetText(CDSO.choiceLine.characterName);
            characterQuote.SetText(CDSO.choiceLine.characterQuote);
            Child.sprite = CDSO.choiceLine.characterIcon;
            leftChoice = false;
        }

        switch (CDSO.choiceEffects.FilledPlant)
        {
            case 1:
                StartCoroutine(littlePlantFilling(30f));
                break;
            case 2:
                StartCoroutine(bigPlantFilling(30f));
                break;
            case -1:
                StartCoroutine(littlePlantDecreasing(30f));
                break;
            case -2:
                StartCoroutine(bigPlantDecreasing(30f));
                break;

        }

        switch (CDSO.choiceEffects.FilledHuman)
        {
            case 1:
                StartCoroutine(littleHumanFilling(30f));
                break;
            case 2:
                StartCoroutine(bigHumanFilling(30f));
                break;
            case -1:
                StartCoroutine(littleHumanDecreasing(30f));
                break;
            case -2:
                StartCoroutine(bigHumanDecreasing(30f));
                break;
        }
        switch (CDSO.choiceEffects.FilledGun)
        {
            case 1:
                StartCoroutine(littleGunFilling(30f));
                break;
            case 2:
                StartCoroutine(bigGunFilling(30f));
                break;
            case -1:
                StartCoroutine(littleGunDecreasing(30f));
                break;
            case -2:
                StartCoroutine(bigGunDecreasing(30f));
                break;
        }
        switch (CDSO.choiceEffects.FilledMoney)
        {
            case 1:
                StartCoroutine(littleMoneyFilling(30f));
                break;
            case 2:
                StartCoroutine(bigMoneyFilling(30f));
                break;
            case -1:
                StartCoroutine(littleMoneyDecreasing(30f));
                break;
            case -2:
                StartCoroutine(bigMoneyDecreasing(30f));
                break;
        }

        
    }


    private void checkDeath()
    {
        {
            if (fillPlant.fillAmount < 0.001)
            {
                if(CDSO.gameOver.plantDeath != null)
                    CDSO = CDSO.gameOver.plantDeath;

            }
            if (fillHuman.fillAmount < 0.001)
            {
                if(CDSO.gameOver.humanDeath != null)
                CDSO = CDSO.gameOver.humanDeath;

            }
            if (fillGun.fillAmount < 0.001)
            {
                if(CDSO.gameOver.gunDeath != null)
                CDSO = CDSO.gameOver.gunDeath;

            }
            if (fillMoney.fillAmount < 0.001)
            {
                if(CDSO.gameOver.moneyDeath != null)
                CDSO = CDSO.gameOver.moneyDeath;

            }
        }
    }
    private IEnumerator littlePlantFilling(float duration)
    {
        currentFilledPlant = fillPlant.fillAmount;

        for (float i = currentFilledPlant; i <= currentFilledPlant + 0.3f; i += (speed * 0.01f))
        {
            fillPlant.fillAmount = i;
            fillPlant.color = Color.green;

            yield return new WaitForEndOfFrame();

        }
        

        fillPlant.color = Color.white;

    }
    private IEnumerator bigPlantFilling(float duration)
    {
        currentFilledPlant = fillPlant.fillAmount;
        for (float i = currentFilledPlant; i <= currentFilledPlant + 0.5f; i += (speed * 0.01f))
        {
            fillPlant.fillAmount = i;
            fillPlant.color = Color.green;

            yield return new WaitForEndOfFrame();

        }
        
        

        
        fillPlant.color = Color.white;

    }
    private IEnumerator littlePlantDecreasing(float duration)
    {
        currentFilledPlant = fillPlant.fillAmount;

        for (float i = currentFilledPlant; i >= currentFilledPlant-0.3f; i -= (speed * 0.01f))
        {
            fillPlant.fillAmount = i;
            fillPlant.color = Color.red;
            yield return new WaitForEndOfFrame();
        }

        
        fillPlant.color = Color.white;

    }
    private IEnumerator bigPlantDecreasing(float duration)
    {
        currentFilledPlant = fillPlant.fillAmount;

        for (float i = currentFilledPlant; i >= currentFilledPlant-0.5f; i -= (speed * 0.01f))
        {
            fillPlant.fillAmount = i;
            fillPlant.color = Color.red;

            yield return new WaitForEndOfFrame();

        }

      
        fillPlant.color = Color.white;

    }
    private IEnumerator littleHumanFilling(float duration)
    {
        currentFilledHuman = fillHuman.fillAmount;

        for (float i = currentFilledHuman; i <= currentFilledHuman + 0.3f; i += (speed * 0.01f))
        {
            fillHuman.fillAmount = i;
            fillHuman.color = Color.green;

            yield return new WaitForEndOfFrame();

        }
        

        fillHuman.color = Color.white;

    }
    private IEnumerator bigHumanFilling(float duration)
    {
        currentFilledHuman = fillHuman.fillAmount;
        for (float i = currentFilledHuman; i <= currentFilledHuman + 0.5f; i += (speed * 0.01f))
        {
            fillHuman.fillAmount = i;
            fillHuman.color = Color.green;

            yield return new WaitForEndOfFrame();

        }

        


        fillHuman.color = Color.white;

    }
    private IEnumerator littleHumanDecreasing(float duration)
    {
        currentFilledHuman = fillHuman.fillAmount;

        for (float i = currentFilledHuman; i >= currentFilledHuman - 0.3f; i -= (speed * 0.01f))
        {
            fillHuman.fillAmount = i;
            fillHuman.color = Color.red;
            yield return new WaitForEndOfFrame();
        }

        
        fillHuman.color = Color.white;

    }
    private IEnumerator bigHumanDecreasing(float duration)
    {
        currentFilledHuman = fillHuman.fillAmount;

        for (float i = currentFilledHuman; i >= currentFilledHuman - 0.5f; i -= (speed * 0.01f))
        {
            fillHuman.fillAmount = i;
            fillHuman.color = Color.red;

            yield return new WaitForEndOfFrame();

        }
        fillHuman.color = Color.white;
    }
    private IEnumerator littleGunFilling(float duration)
    {
        currentFilledGun = fillGun.fillAmount;

        for (float i = currentFilledGun; i <= currentFilledGun + 0.3f; i += (speed * 0.01f))
        {
            fillGun.fillAmount = i;
            fillGun.color = Color.green;

            yield return new WaitForEndOfFrame();

        }
        fillGun.color = Color.white;
    }
    private IEnumerator bigGunFilling(float duration)
    {
        currentFilledGun = fillGun.fillAmount;
        for (float i = currentFilledGun; i <= currentFilledGun + 0.5f; i += (speed * 0.01f))
        {
            fillGun.fillAmount = i;
            fillGun.color = Color.green;

            yield return new WaitForEndOfFrame();

        }
        fillGun.color = Color.white;
    }
    private IEnumerator littleGunDecreasing(float duration)
    {
        currentFilledGun = fillGun.fillAmount;

        for (float i = currentFilledGun; i >= currentFilledGun - 0.3f; i -= (speed * 0.01f))
        {
            fillGun.fillAmount = i;
            fillGun.color = Color.red;
            yield return new WaitForEndOfFrame();
        }
        fillGun.color = Color.white;
    }
    private IEnumerator bigGunDecreasing(float duration)
    {
        currentFilledGun = fillGun.fillAmount;

        for (float i = currentFilledGun; i >= currentFilledGun - 0.5f; i -= (speed * 0.01f))
        {
            fillGun.fillAmount = i;
            fillGun.color = Color.red;

            yield return new WaitForEndOfFrame();

        }
        fillGun.color = Color.white;

    }
    private IEnumerator littleMoneyFilling(float duration)
    {
        currentFilledMoney = fillMoney.fillAmount;

        for (float i = currentFilledMoney; i <= currentFilledMoney + 0.3f; i += (speed * 0.01f))
        {
            fillMoney.fillAmount = i;
            fillMoney.color = Color.green;

            yield return new WaitForEndOfFrame();

        }
        fillMoney.color = Color.white;
    }
    private IEnumerator bigMoneyFilling(float duration)
    {
        currentFilledMoney = fillMoney.fillAmount;
        for (float i = currentFilledMoney; i <= currentFilledMoney + 0.5f; i += (speed * 0.01f))
        {
            fillMoney.fillAmount = i;
            fillMoney.color = Color.green;

            yield return new WaitForEndOfFrame();

        }
        fillMoney.color = Color.white;
    }
    private IEnumerator littleMoneyDecreasing(float duration)
    {
        currentFilledMoney = fillMoney.fillAmount;

        for (float i = currentFilledMoney; i >= currentFilledMoney - 0.3f; i -= (speed * 0.01f))
        {
            fillMoney.fillAmount = i;
            fillMoney.color = Color.red;
            yield return new WaitForEndOfFrame();
        }
        fillMoney.color = Color.white;
    }
    private IEnumerator bigMoneyDecreasing(float duration)
    {
        currentFilledMoney = fillMoney.fillAmount;

        for (float i = currentFilledMoney; i >= currentFilledMoney - 0.5f; i -= (speed * 0.01f))
        {
            fillMoney.fillAmount = i;
            fillMoney.color = Color.red;

            yield return new WaitForEndOfFrame();

        }
        fillMoney.color = Color.white;

    }
}
