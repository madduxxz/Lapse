using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DynamicBox.EventManagement;
public class MenuController : MonoBehaviour
{
    [SerializeField] private SettingsPanelView view;


   
    public void OnSettingsButtonPressHandler()
    {
        view.ShowSettings();
    }
    public void OnShopButtonPressHandler()
    {
        view.ShowShop();
    }
    public void OnProgressButtonPressHandler()
    {
        view.ShowProgress();
    }
    public void ContinueButtonHandler()
    {
        view.ContinueButton();
    }
    public void ExitButton()
    {
        view.ExitButton();
    }
    //public void Eng()
    //{
    //    view.settoEng();
    //}
    //public void Az()
    //{
    //    view.settoAz();
    //}
    //public void Tr()
    //{
    //    view.settoTr();
    //}
    public void LanguagePanel()
    {
        view.openLanguagePanel();
    }
}

