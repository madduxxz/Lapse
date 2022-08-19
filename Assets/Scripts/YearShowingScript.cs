using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class YearShowingScript : MonoBehaviour
{
    [SerializeField] private GameObject MainPanel;
    [SerializeField] private GameObject EyePanel;
    [SerializeField] private GameObject RewardPanel;
    [SerializeField] private GameObject SettingsPanel;
    [SerializeField] private Button Settings;
    [SerializeField] private GameObject GameplayScene;
    [SerializeField] private GameObject FadeInOut;
    [SerializeField] private GameObject PlayingArea;
    
    private void ShowSettingsPanel()
    {
        MainPanel.SetActive(true);
        SettingsPanel.SetActive(true);
        EyePanel.SetActive(false);
        RewardPanel.SetActive(false);
        Settings.Select();
    }
    private void ExitButton()
    {
        MainPanel.SetActive(false);
        
        
    }
    private void ShowEyePanel()
    {
        MainPanel.SetActive(true);
        EyePanel.SetActive(true);
        SettingsPanel.SetActive(false);
        RewardPanel.SetActive(false);


    }
    private void ShowRewardPanel()
    {
        MainPanel.SetActive(true);
        RewardPanel.SetActive(true);
        EyePanel.SetActive(false);
        SettingsPanel.SetActive(false);
    }
    private void CourtineStarter()
    {
        StartCoroutine(Continue());

    }
    private IEnumerator Continue()
    {
        FadeInOut.SetActive(true);
        yield return new WaitForSeconds(1f);
        GameplayScene.SetActive(true);
        yield return new WaitForSeconds(4f);
        PlayingArea.SetActive(true);
        
        
        yield return new WaitForSeconds(1f);
        FadeInOut.SetActive(false);
        gameObject.SetActive(false);
        
    }
   
}
