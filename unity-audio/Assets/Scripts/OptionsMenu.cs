using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour
{
    public Toggle invertY;
    private string previousScene;
    private bool invert;
    public AudioMixer audioMixer;
    public Slider bgmSlider;
    private const string BGM_VOLUME_KEY = "BGMVolume";
    private const float VOLUME_MIN_DB = -80f;
    private const float VOLUME_MAX_DB = 0f;
    private float currentBGMValue;
    

    private void Start()
    {
        previousScene = PlayerPrefs.GetString("Previous", "MainMenu");
        invertY.isOn = PlayerPrefs.GetInt("InvertY", 0) == 1;
        LoadBGMVolume();
        bgmSlider.onValueChanged.AddListener(HandleBGMSliderChanged);
    }

    public void Back()
    {
        float savedVolume = PlayerPrefs.GetFloat(BGM_VOLUME_KEY, 1f);
        SetBGMVolume(savedVolume);
        SceneManager.LoadScene(previousScene);
    }

    public void Apply()
    {
        invert = invertY.isOn;
        PlayerPrefs.SetInt("InvertY", invert ? 1 : 0);
        PlayerPrefs.SetFloat(BGM_VOLUME_KEY, currentBGMValue);
        SceneManager.LoadScene(previousScene);
    }

    private void LoadBGMVolume()
    {
        float savedVolume = PlayerPrefs.GetFloat(BGM_VOLUME_KEY, 1f);
        currentBGMValue = savedVolume;
        bgmSlider.value = savedVolume;
        SetBGMVolume(savedVolume);
    }

    private void SetBGMVolume(float value)
    {
        float dbVal = Mathf.Lerp(VOLUME_MIN_DB, VOLUME_MAX_DB, value);
        if (value <= 0)
            dbVal = -80f;
        audioMixer.SetFloat("BGMVolume", dbVal);
    }

    private void HandleBGMSliderChanged(float value)
    {
        currentBGMValue = value;
        SetBGMVolume(value);
    }




}
