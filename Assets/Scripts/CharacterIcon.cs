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

    [SerializeField] private AudioSource paperSound;

    [SerializeField] ChoiceDataSO Death;
    [SerializeField] ChoiceDataSO RickNMorty;

    [SerializeField] GameObject deathCrystal;

    private bool rightChoice = false;

    private bool leftChoice = false;

    private Animator anim;

    private float oppacity1;

    private float oppacity2;

    public ChoiceDataSO CDSO;

    private ChoiceDataSO[] Cards;

    private int randomChoice;


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
            paperSound.Play();
            StartCoroutine("CheckRight");
            rightChoice = true;
            StartCoroutine("DeactiveAndReactivate");


        }
        if (RT.anchoredPosition.x < -240F && !leftChoice)
        {
            anim.SetInteger("IconAnim", 2);
            paperSound.Play();
            StartCoroutine("CheckLeft");
            leftChoice = true;
            StartCoroutine("DeactiveAndReactivate");
        }
        oppacity1 = RT.anchoredPosition.x / -150;
        choice1.color = new Color(1f, 1f, 1f, oppacity1);

        oppacity2 = RT.anchoredPosition.x / 150;
        choice2.color = new Color(1f, 1f, 1f, oppacity2);

        


    }

    private IEnumerator CheckRight()
    {
        yield return new WaitForSeconds(0.6f);
        effectCheckRight();
    }
    private IEnumerator CheckLeft()
    {
        yield return new WaitForSeconds(0.6f);
        effectCheckLeft();
    }

    private void checkYear()
    {
        if ((int.Parse(dayInfo.GetParsedText()) / 365 >= 1))
        {

            CDSO.choiceLine.yearInfo =int.Parse(yearInfo.GetParsedText());
            yearInfo.SetText((CDSO.choiceLine.yearInfo + 1f).ToString());
            ;
            CDSO.choiceLine.dayInfo -= 365;
        }
    }
    private IEnumerator DeactiveAndReactivate()
    {
        if (CDSO.choiceLine.characterName == "???")
        {
            SettingsPanelView.Current.ChangeToPast();
        }
        if(CDSO.choiceLine.yearInfo == 1)
        {
            deathCrystal.SetActive(true);
        }

        yield return new WaitForSeconds(1.5f);
        anim.SetInteger("IconAnim", 3);
        CDSO.choiceLine.dayInfo = int.Parse(dayInfo.GetParsedText());
        checkYear();
        dayInfo.SetText((CDSO.choiceLine.dayInfo + Random.Range(2, 10)).ToString());
        if (rightChoice)
        {

            if (CheckPlantDeath())
                CDSO = CDSO.gameOver.plantDeath;

            if (CheckHumanDeath())
                CDSO = CDSO.gameOver.humanDeath;

            if (CheckGunDeath())
                CDSO = CDSO.gameOver.gunDeath;
            if (CheckMoneyDeath())
                CDSO = CDSO.gameOver.moneyDeath;



            if (!CheckPlantDeath() && !CheckHumanDeath() && !CheckGunDeath() && !CheckMoneyDeath())
                CDSO = CDSO.nextStates.nextState2;


            ChoiceSetter();
            rightChoice = false;
        }
        if (leftChoice)
        {

            if (CheckPlantDeath())
                CDSO = CDSO.gameOver.plantDeath;

            if (CheckHumanDeath())
                CDSO = CDSO.gameOver.humanDeath;

            if (CheckGunDeath())
                CDSO = CDSO.gameOver.gunDeath;
            if (CheckMoneyDeath())
                CDSO = CDSO.gameOver.moneyDeath;



            if (!CheckPlantDeath() && !CheckHumanDeath() && !CheckGunDeath() && !CheckMoneyDeath())
                CDSO = CDSO.nextStates.nextState1;

            ChoiceSetter();
            leftChoice = false;
        }
        if (CDSO == Death)
        {

            StartCoroutine(EndGame());
            
        }

        


    }

        


    private IEnumerator EndGame()
    {
        SettingsPanelView.Current.DeathCourtine();
        yield return new WaitForSeconds(2f);
        Cards = Resources.LoadAll<ChoiceDataSO>("Data/ChoiceData/MainChoices") as ChoiceDataSO[];
        randomChoice = Random.Range(0, Cards.Length);
        FillAmountRestart();
        CDSO = Cards[randomChoice];
        ChoiceSetter();
    }
    private void FillAmountRestart()
    {
        fillPlant.fillAmount = 0.5f;
        fillHuman.fillAmount = 0.5f;
        fillGun.fillAmount = 0.5f;
        fillMoney.fillAmount = 0.5f;
    }

    private void ChoiceSetter()
    {
        choice1.SetText(CDSO.nextStates.StateQuoteleft);
        choice2.SetText(CDSO.nextStates.StateQuoteright);
        characterName.SetText(CDSO.choiceLine.characterName);
        characterQuote.SetText(CDSO.choiceLine.characterQuote);
        Child.sprite = CDSO.choiceLine.characterIcon;
    }

    private bool CheckPlantDeath()
    {
        if (fillPlant.fillAmount < 0.001)
        {
            if (CDSO.gameOver.plantDeath != null)
            {

                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
    private bool CheckHumanDeath()
    {
        if (fillHuman.fillAmount < 0.001)
        {
            if (CDSO.gameOver.humanDeath != null)
            {

                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
    private bool CheckGunDeath()
    {
        if (fillGun.fillAmount < 0.001)
        {
            if (CDSO.gameOver.gunDeath != null)
            {

                return true;
            }
            else { return false; }


        }
        else
        {
            return false;
        }
    }
    private bool CheckMoneyDeath()
    {
        if (fillMoney.fillAmount < 0.001)
        {
            if (CDSO.gameOver.moneyDeath != null)
            {

                return true;
            }
            else { return false; }

        }
        else
        {
            return false;
        }
    }
    private IEnumerator PlantFilling(float duration, float change)
    {
        currentFilledPlant = fillPlant.fillAmount;
        if (change > 0)
        {
            for (float i = currentFilledPlant; i <= currentFilledPlant + change; i += (speed * 0.014f))
            {
                fillPlant.fillAmount = i;
                fillPlant.color = Color.green;

                yield return new WaitForEndOfFrame();

            }
        }
        if (change < 0)
        {
            for (float i = currentFilledPlant; i >= currentFilledPlant + change; i -= (speed * 0.014f))
            {
                fillPlant.fillAmount = i;
                fillPlant.color = Color.red;

                yield return new WaitForEndOfFrame();

            }
        }
        fillPlant.color = Color.white;
    }
    private IEnumerator HumanFilling(float duration, float change)
    {
        currentFilledHuman = fillHuman.fillAmount;
        if (change > 0)
        {
            for (float i = currentFilledHuman; i <= currentFilledHuman + change; i += (speed * 0.014f ))
            {
                fillHuman.fillAmount = i;
                fillHuman.color = Color.green;

                yield return new WaitForEndOfFrame();

            }
        }
        if (change < 0)
        {
            for (float i = currentFilledHuman; i >= currentFilledHuman + change; i -= (speed * 0.014f ))
            {
                fillHuman.fillAmount = i;
                fillHuman.color = Color.red;

                yield return new WaitForEndOfFrame();

            }
        }
        fillHuman.color = Color.white;
    }
    private IEnumerator GunFilling(float duration, float change)
    {
        currentFilledGun = fillGun.fillAmount;
        if (change > 0)
        {
            for (float i = currentFilledGun; i <= currentFilledGun + change; i += (speed * 0.014f))
            {
                fillGun.fillAmount = i;
                fillGun.color = Color.green;

                yield return new WaitForEndOfFrame();

            }
        }
        if (change < 0)
        {
            for (float i = currentFilledGun; i >= currentFilledGun + change; i -= (speed * 0.014f ))
            {
                fillGun.fillAmount = i;
                fillGun.color = Color.red;

                yield return new WaitForEndOfFrame();

            }
        }
        fillGun.color = Color.white;
    }
    private IEnumerator MoneyFilling(float duration, float change)
    {
        currentFilledMoney = fillMoney.fillAmount;
        if (change > 0)
        {
            for (float i = currentFilledMoney; i <= currentFilledMoney + change; i += (speed * 0.014f))
            {
                fillMoney.fillAmount = i;
                fillMoney.color = Color.green;

                yield return new WaitForEndOfFrame();

            }
        }
        if (change < 0)
        {
            for (float i = currentFilledMoney; i >= currentFilledMoney + change; i -= (speed * 0.014f ))
            {
                fillMoney.fillAmount = i;
                fillMoney.color = Color.red;

                yield return new WaitForEndOfFrame();

            }
        }
        fillMoney.color = Color.white;
    }
    private void effectCheckLeft()
    {
        if (CDSO.choiceEffectsLeft.FilledPlant != 0)
            StartCoroutine(PlantFilling(20f, CDSO.choiceEffectsLeft.FilledPlant));
        if (CDSO.choiceEffectsLeft.FilledHuman != 0)
            StartCoroutine(HumanFilling(20f, CDSO.choiceEffectsLeft.FilledHuman));
        if (CDSO.choiceEffectsLeft.FilledGun != 0)
            StartCoroutine(GunFilling(20f, CDSO.choiceEffectsLeft.FilledGun));
        if (CDSO.choiceEffectsLeft.FilledMoney != 0)
            StartCoroutine(MoneyFilling(20f, CDSO.choiceEffectsLeft.FilledMoney));


    }
    private void effectCheckRight()
    {
        if (CDSO.choiceEffectsRight.FilledPlant != 0)
            StartCoroutine(PlantFilling(20f, CDSO.choiceEffectsRight.FilledPlant));
        if (CDSO.choiceEffectsRight.FilledHuman != 0)
            StartCoroutine(HumanFilling(20f, CDSO.choiceEffectsRight.FilledHuman));
        if (CDSO.choiceEffectsRight.FilledGun != 0)
            StartCoroutine(GunFilling(20f, CDSO.choiceEffectsRight.FilledGun));
        if (CDSO.choiceEffectsRight.FilledMoney != 0)
            StartCoroutine(MoneyFilling(20f, CDSO.choiceEffectsRight.FilledMoney));


    }
}
    
