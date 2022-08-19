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
    void Start()
    {
        StartCoroutine(CountUpToTarget(2075, 2f));
    }
    IEnumerator CountUpToTarget(int targetVal, float duration, float delay = 0f, string prefix = "")
    {
        
        if (delay > 0)
        {
            yield return new WaitForSeconds(delay);
        }
        int current = 1;
        int currentNonZero = 1;
        while (current < targetVal)
        {
            // ensure "current" is not getting a value of zero, resulting in an infinite loop
            currentNonZero = (int)(targetVal / (duration / Time.deltaTime));
            if (currentNonZero == 0)
            {
                currentNonZero = 1;
            }
            // step by amount that will get us to the target value within the duration
            current += currentNonZero;
            current = Mathf.Clamp(current, 0, targetVal);
            YearText.text = prefix + current;
            yield return null;
        }
        ContinueText.SetActive(true);
        Continue.interactable = true;

    }
}
