using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class YearScript : MonoBehaviour
{
    [SerializeField] private TMP_Text YearText;
    [SerializeField] private GameObject ContinueText;
    [SerializeField] private Button Continue;
    [SerializeField] private TMP_Text yearInfo;
    public static YearScript countUp { get; private set; }

    private void Awake()
    {
        if(countUp != null && countUp != this)
        {
            Destroy(this);
        }
        else
        {
            countUp = this;
        }
    }
    void Start()
    {

        CountUpStarter();
    }
    public void CountUpStarter()
    {
        JsonReadWriteSystem.Instance.SaveToJson();
        JsonReadWriteSystem.Instance.LoadFromJson();
        StartCoroutine(CountUpToTarget(JsonReadWriteSystem.Instance.yearCount, 2f));
    }
    public IEnumerator CountUpToTarget(int targetVal, float duration, float delay = 0f, string prefix = "")
    {
        ContinueText.SetActive(false);
        Continue.interactable = false;
        if (delay > 0)
        {
            yield return new WaitForSeconds(delay);
        }
        int current = 1;
        int currentNonZero = 1;
        while (current < targetVal)
        {
            
            currentNonZero = (int)(targetVal / (duration / Time.deltaTime));
            if (currentNonZero == 0)
            {
                currentNonZero = 1;
            }
           
            current += currentNonZero;
            current = Mathf.Clamp(current, 0, targetVal);
            YearText.text = prefix + current;
            yield return null;
        }
        ContinueText.SetActive(true);
        Continue.interactable = true;

    }
}
