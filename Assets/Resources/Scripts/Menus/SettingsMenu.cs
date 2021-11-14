using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    private Resolution[] resolutions;
    public TMP_Dropdown resolutionDropdown;
    public Toggle fullscreenToggle;

    private void Start()
    {
        resolutions = Screen.resolutions;
        List<string> resolutionsList = new List<string>();
        int currentResolutionIdx = 0;
        foreach (Resolution res in resolutions)
        {
            resolutionsList.Add(res.width + "X" + res.height);
            if (res.height == Screen.height
                && res.width == Screen.width)
            {
                currentResolutionIdx = resolutionsList.Count - 1;
            }
        }
        resolutionDropdown.ClearOptions();
        resolutionDropdown.AddOptions(resolutionsList);
        resolutionDropdown.value = currentResolutionIdx;
        resolutionDropdown.RefreshShownValue();

        fullscreenToggle.isOn = Screen.fullScreen;
    }
    public void SetMasterVolume(float volume)
    {
        audioMixer.SetFloat("masterVolume", volume);
    }

    public void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat("musicVolume", volume);
    }

    public void SetSFXVolume(float volume)
    {
        audioMixer.SetFloat("sfxVolume", volume);
        FindObjectOfType<AudioManager>().PlayClip("pop1");
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution targetResolution = resolutions[resolutionIndex];
        Screen.SetResolution(targetResolution.width, targetResolution.height, Screen.fullScreen);
        Debug.Log(Screen.resolutions.ToString());
    }
}
