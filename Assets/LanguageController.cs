using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using TMPro;
public class LanguageController : MonoBehaviour
{
    [SerializeField] GameObject languagePanel;
    [SerializeField] TMP_Text currentLanguage;
 public void openLanguagePanel()
    {
        languagePanel.SetActive(true);
        
    }
    public void SetSelectedLocale(Locale locale)
    {
        LocalizationSettings.SelectedLocale = locale;
    }
    public void settoEng()
    {
        SetSelectedLocale(LocalizationSettings.AvailableLocales.Locales[0]);
        currentLanguage.SetText("English >");
    }
    public void settoAz()
    {
        SetSelectedLocale(LocalizationSettings.AvailableLocales.Locales[1]);
        currentLanguage.SetText("Azerbaijani >");
    }
    public void settoTr()
    {
        SetSelectedLocale(LocalizationSettings.AvailableLocales.Locales[2]);
        currentLanguage.SetText("Turkish >");
    }
}
