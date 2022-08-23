using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
namespace DynamicBox.UIViews {
    public class SettingsPanelView : MonoBehaviour
    {
        [Header("Controller")]
        [SerializeField] private MenuController controller;

        [Header("View")]
        [SerializeField] private GameObject mainPanel;
        [SerializeField] private GameObject settingsPanel;
        [SerializeField] private GameObject shopPanel;
        [SerializeField] private GameObject progressPanel;
        [SerializeField] private TMP_Text panelText;
        [SerializeField] private GameObject fadeInOut;
        [SerializeField] private GameObject GameplayScene;
        [SerializeField] private GameObject PlayingArea;
        [SerializeField] GameObject languagePanel;
        [SerializeField] TMP_Text currentLanguage;

        public void ShowSettings()
        {
            mainPanel.SetActive(true);
            settingsPanel.SetActive(true);
            shopPanel.SetActive(false);
            progressPanel.SetActive(false);
            panelText.SetText("Settings");
    }
        public void ShowShop()
        {
            mainPanel.SetActive(true);
            settingsPanel.SetActive(false);
            shopPanel.SetActive(true);
            progressPanel.SetActive(false);
            panelText.SetText("Active effects");
        }
        public void ShowProgress()
        {
            mainPanel.SetActive(true);
            settingsPanel.SetActive(false);
            shopPanel.SetActive(false);
            progressPanel.SetActive(true);
            panelText.SetText("Progress");
        }
        public void ExitButton()
        {
            mainPanel.SetActive(false);
        }
        public void ContinueButton()
        {
            StartCoroutine(Continue());

        }
        public IEnumerator Continue()
        {
            fadeInOut.SetActive(true);
            yield return new WaitForSeconds(1f);
            GameplayScene.SetActive(true);
            yield return new WaitForSeconds(4f);
            PlayingArea.SetActive(true);


            yield return new WaitForSeconds(1f);
            fadeInOut.SetActive(false);
          

        }
        public void openLanguagePanel()
        { 
            languagePanel.SetActive(!languagePanel.activeInHierarchy);
        }
        public void SetSelectedLocale(Locale locale)
        {
            LocalizationSettings.SelectedLocale = locale;
        }
        public void setLanguage(int index)
        {
            SetSelectedLocale(LocalizationSettings.AvailableLocales.Locales[index]);
            
        }
        //public void settoAz()
        //{
        //    SetSelectedLocale(LocalizationSettings.AvailableLocales.Locales[1]);
        //    currentLanguage.SetText("Azerbaijani >");
        //}
        //public void settoTr()
        //{
        //    SetSelectedLocale(LocalizationSettings.AvailableLocales.Locales[2]);
        //    currentLanguage.SetText("Turkish >");
        //}
    }
}