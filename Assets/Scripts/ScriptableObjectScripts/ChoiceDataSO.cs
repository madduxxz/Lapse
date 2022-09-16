using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu(fileName ="NewChoiceData", menuName ="ScriptableObjects/ChoiceData")]
public class ChoiceDataSO : ScriptableObject
{
    public ChoiceLine choiceLine;
    public ChoiceState nextStates;
    public EffectsOfChoicesLeft choiceEffectsLeft;
    public EffectsOfChoicesRight choiceEffectsRight;
    public GameOver gameOver;
  
}


[System.Serializable]
public class ChoiceLine
{
    public string characterName;

    public Sprite characterIcon;

    public AudioClip cardNoise;
    
    public int yearInfo;

    public int dayInfo;

    [TextArea(5,10)]
    public string characterQuote;
}
[System.Serializable]
public class ChoiceState
{
    [TextArea(5, 10)]
    public string StateQuoteleft;
    [TextArea(5, 10)]
    public string StateQuoteright;

    public ChoiceDataSO nextState1;

    public ChoiceDataSO nextState2;
}
[System.Serializable]
public class EffectsOfChoicesLeft
{
    public float FilledPlant;
    public float FilledHuman;
    public float FilledGun;
    public float FilledMoney;
}

[System.Serializable]
public class EffectsOfChoicesRight
{
    public float FilledPlant;
    public float FilledHuman;
    public float FilledGun;
    public float FilledMoney;
}

[System.Serializable]
public class GameOver
{
    public ChoiceDataSO plantDeath;

    public ChoiceDataSO humanDeath;

    public ChoiceDataSO gunDeath;

    public ChoiceDataSO moneyDeath;
}