using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RicScript : MonoBehaviour
{
    [SerializeField] private TMP_Text YearText;
    [SerializeField] public Animation portalFlush;
    public static RicScript countDown { get; private set; }

    private void Awake()
    {
        if (countDown != null && countDown != this)
        {
            Destroy(this);
        }
        else
        {
            countDown = this;
        }
    }
    void Start()
    {
        CountDownStarter();
    }
    public void CountDownStarter()
    {
        StartCoroutine(CountDownToTarget(90000, 13f));
    }
    public IEnumerator CountDownToTarget(int targetVal, float duration, float delay = 0f, string prefix = "")
    {
        
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


    }
}
