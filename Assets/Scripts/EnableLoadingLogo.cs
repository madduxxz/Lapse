using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class EnableLoadingLogo : MonoBehaviour
{
    [SerializeField] private GameObject LoadingButton;
    [SerializeField] private GameObject LoadingLogo;
    [SerializeField] private TMP_Text RadiationLevelText;
    [SerializeField] private GameObject TouchText;
    [SerializeField] private AudioSource ButtonSound;
    AsyncOperation asyncLoadScene;
    
    private Animator anim;
    
    void Start()
    {
        
        anim = TouchText.GetComponent<Animator>();
        StartCoroutine(ButtonEnable());
    }

    private IEnumerator ButtonEnable()
    {
        yield return new WaitForSeconds(2f);
        LoadingButton.SetActive(true);
        TouchText.SetActive(true);
    }

    public void ChangeToLoad()
    {
        LoadingLogo.SetActive(true);
        StartCoroutine(ChangeScene());
        RadiationLevelText.text = "CHECKING RADIATION LEVEL";
        RadiationLevelText.color = Color.white;
        anim.enabled = false;
        ButtonSound.Play();
    }
    private IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(2f);
        asyncLoadScene = SceneManager.LoadSceneAsync("GameplayScene", LoadSceneMode.Single);
        
    }
    
    
}
