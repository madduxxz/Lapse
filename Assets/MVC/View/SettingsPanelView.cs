using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;
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
    [SerializeField] private GameObject gameplayScene;
    [SerializeField] private GameObject playingArea;
    [SerializeField] GameObject languagePanel;
    [SerializeField] TMP_Text currentLanguage;
    [SerializeField] AudioSource ContinueSound;
    [SerializeField] AudioSource backgroundMusic;
    [SerializeField] GameObject Music;
    [SerializeField] GameObject soundEffects;
    [SerializeField] AudioSource ButtonSound1;
    [SerializeField] AudioSource ButtonSound2;
    [SerializeField] GameObject rickPlayScene;
    [SerializeField] GameObject yearScene;
    [SerializeField] GameObject rickShowingScene;
    [SerializeField] AudioSource rickGroundMusic;
    [SerializeField] GameObject Portal;
    [SerializeField] AudioSource PortalOpeningSound;
    [SerializeField] AudioSource PortalClosingSound;
    [SerializeField] GameObject RickNMortyArea;
    

    public static SettingsPanelView Current { get; private set; }

        private void Awake()
        {
            if (Current != null && Current != this)
            {
                Destroy(this);
            }
            else
            {
                Current = this;
            }
        }
        public void ShowSettings()
        {
        ButtonSound1.Play();   
        mainPanel.SetActive(true);  
        settingsPanel.SetActive(true);
        shopPanel.SetActive(false);
        progressPanel.SetActive(false);
            
    }
        public void ShowShop()
        {
        ButtonSound1.Play();
        mainPanel.SetActive(true);
        settingsPanel.SetActive(false);
        shopPanel.SetActive(true);
        progressPanel.SetActive(false);
            
        }
        public void ShowProgress()
        {
        ButtonSound1.Play();
        mainPanel.SetActive(true);  
        settingsPanel.SetActive(false);
        shopPanel.SetActive(false);
        progressPanel.SetActive(true);
        }
        public void ExitButton()
        {
        ButtonSound2.Play();
        mainPanel.SetActive(false);
        }
        public void ContinueButton()
        {
            StartCoroutine(Continue());

        }
        public IEnumerator Continue()
        {
            ContinueSound.Play();
            fadeInOut.SetActive(true);
            yield return new WaitForSeconds(1f);
            gameplayScene.SetActive(true);
            backgroundMusic.Play();
            yield return new WaitForSeconds(1f);
            fadeInOut.SetActive(false);
            yield return new WaitForSeconds(3f);
            playingArea.SetActive(true);
        }

        public void openLanguagePanel()
        {
        ButtonSound1.Play();
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
        public IEnumerator Death()
        {
            
            yield return new WaitForSeconds(1f);
            fadeInOut.SetActive(true);
            yield return new WaitForSeconds(1f);
            gameplayScene.SetActive(false);
            YearScript.countUp.CountUpStarter();
            yield return new WaitForSeconds(1f);

            
            fadeInOut.SetActive(false);
        }
        
        public void DeathCourtine()
        {
            StartCoroutine(Death());
        }
       public void OnClickMusic()
      {
        Music.SetActive(!Music.activeInHierarchy);
        if(gameplayScene.activeInHierarchy)
        backgroundMusic.Play();

      }
    public void OnClickSoundeff()
    {
        soundEffects.SetActive(!soundEffects.activeInHierarchy);

    }
    public void ChangeToPast()
    {
        StartCoroutine(Past());
    }
    public IEnumerator Past()
    {
        yield return new WaitForSeconds(1f);
        fadeInOut.SetActive(true);
        
        yield return new WaitForSeconds(1f);
        rickShowingScene.SetActive(true);
        
        
        
        RicScript.countDown.CountDownStarter();
        yield return new WaitForSeconds(1f);
        fadeInOut.SetActive(false);
        backgroundMusic.Stop();
        backgroundMusic = rickGroundMusic;
        backgroundMusic.Play();
        gameplayScene.SetActive(false);
        yield return new WaitForSeconds(4f);
        Portal.SetActive(true);
        
        PortalOpeningSound.Play();

        yearScene.SetActive(false);
        
        yield return new WaitForSeconds(1f);
        
        PortalClosingSound.Play();
        yield return new WaitForSeconds(0.7f);
        rickPlayScene.SetActive(true);
        yield return new WaitForSeconds(0.6f);
        RicScript.countDown.portalFlush.Play();
        ContinueRickButton();


    }
    public void ContinueRickButton()
    {
        StartCoroutine(ContinueRick());
    }
    public IEnumerator ContinueRick()
    {
        yield return new WaitForSeconds(3f);
        RickNMortyArea.SetActive(true);
    }

}
