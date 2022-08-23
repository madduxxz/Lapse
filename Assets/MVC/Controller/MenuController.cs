using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DynamicBox.UIViews;
using DynamicBox.EventManagement;
public class MenuController : MonoBehaviour
{
    [SerializeField] private SettingsPanelView view;


    private void OnEnable()
    {
        EventManager.Instance.AddListener<OnSettingsButtonPressedEvent>(OnSettingsButtonPressHandler);
        EventManager.Instance.AddListener<OnShopButtonPressedEvent>(OnShopButtonPressHandler);
        EventManager.Instance.AddListener<OnProgressButtonPressedEvent>(OnProgressButtonPressHandler);
    }
    private void OnDisable()
    {
        EventManager.Instance.RemoveListener<OnSettingsButtonPressedEvent>(OnSettingsButtonPressHandler);
        EventManager.Instance.RemoveListener<OnShopButtonPressedEvent>(OnShopButtonPressHandler);
        EventManager.Instance.RemoveListener<OnProgressButtonPressedEvent>(OnProgressButtonPressHandler);
    }

    public void OnSettingsButtonPressHandler(OnSettingsButtonPressedEvent eventDetails)
    {
        view.ShowSettings();
    }
    public void OnShopButtonPressHandler(OnShopButtonPressedEvent eventDetails)
    {
        view.ShowShop();
    }
    public void OnProgressButtonPressHandler(OnProgressButtonPressedEvent eventDetails)
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
    public void Eng()
    {
        view.settoEng();
    }
    public void Az()
    {
        view.settoAz();
    }
    public void Tr()
    {
        view.settoTr();
    }
    public void LanguagePanel()
    {
        view.openLanguagePanel();
    }
}

