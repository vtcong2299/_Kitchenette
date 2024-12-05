using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIMenuGame : MonoBehaviour
{
    public GameObject panelMenuGame;
    public GameObject panelOptions;
    public GameObject panelPreparePlay;
    public GameObject panelLoading;
    public Slider loadingBar;
    [SerializeField]
    private AudioSource audioSource1;
    [SerializeField]
    private AudioSource audioSource2;
    [SerializeField] 
    private AudioClip musicClip; 
    [SerializeField] 
    private AudioClip clickClip;
    [SerializeField]
    private Text txtPercent;
    private void Awake()
    {
        audioSource1.clip = musicClip;
        panelMenuGame.SetActive(true);
        SetAllPanelFalse();
    }
    private void Start()
    {
        StartCoroutine(SoundMusic());
    }
    public void OnClickPlay()
    {
        SoundClick();
        panelPreparePlay.SetActive(true);
        panelMenuGame.SetActive(false);
    }
    public void OnClickStartGame()
    {
        SoundClick();
        SetAllPanelFalse();
        panelLoading.SetActive(true);
        StartCoroutine(LoadSceneAsync());
    }
    public void OnClickOptions()
    {
        SoundClick();
        panelOptions.SetActive(true);
        panelMenuGame.SetActive(false);
    }
    public void OnClickBack()
    {
        SoundClick();
        panelMenuGame.SetActive(true);
        SetAllPanelFalse();
    }
    public void OnClickExit()
    {
        SoundClick();
        Application.Quit();
    }
    public void SetAllPanelFalse()
    {
        panelOptions.SetActive(false );
        panelPreparePlay.SetActive(false);
        panelLoading.SetActive(false);  
    }
    IEnumerator LoadSceneAsync()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(1);
        operation.allowSceneActivation = false;
        float progress = 0;
        while (!operation.isDone)
        {
            progress = Mathf.MoveTowards(progress, operation.progress,Time.deltaTime);
            loadingBar.value = progress;
            txtPercent.text = Math.Round(progress * 100,0) + "%";
            if (progress >= 0.9f)
            {
                loadingBar.value = 1f;
                operation.allowSceneActivation = true;
            }
            yield return null;
        }
    }
    IEnumerator SoundMusic()
    {
        audioSource1.Play();
        while (true)
        {
            yield return new WaitForSeconds(11);
            audioSource1.Play();
        }
    }
    public void SoundClick()
    {
        audioSource2.clip = clickClip;
        audioSource2.Play();
    }
}
