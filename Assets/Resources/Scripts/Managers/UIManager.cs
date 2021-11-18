using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;
using UnityEngine.Playables;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine.EventSystems;
using Sirenix.OdinInspector;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;
    public static UIManager GetInstance()
    {
        return instance;
    }


    [Header("Main")]
    EventSystem eventSystem;

    [FoldoutGroup("Settings")]
    Resolution[] resolutions;
    [FoldoutGroup("Settings")]
    [SerializeField]
    public TMP_Dropdown resolutionDropdown;
    [FoldoutGroup("Settings")]
    [SerializeField]
    public Toggle fullscreenToggle;
    [FoldoutGroup("Settings")]
    [SerializeField]
    static AudioMixer audioMixer;

    [FoldoutGroup("Planning Screen")]
    [SerializeField]
    GameObject PlanningUI;
    [FoldoutGroup("Planning Screen")]
    [SerializeField]
    TextMeshProUGUI PlanningBugInfo;
    [FoldoutGroup("Planning Screen")]
    [SerializeField]
    GameObject EntryTemplate;
    [FoldoutGroup("Planning Screen")]
    List<GameObject> planningEntries = new List<GameObject>();
    [FoldoutGroup("Planning Screen")]
    int currentEntryIdx;

    [Header("UI State")]
    bool isPlanning;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
        instance = this;
    }

    void Start()
    {
        eventSystem = EventSystem.current;

        // Settings Start()
        //resolutions = Screen.resolutions;
        //List<string> resolutionsList = new List<string>();
        //int currentResolutionIdx = 0;
        //foreach (Resolution res in resolutions)
        //{
        //    resolutionsList.Add(res.width + "X" + res.height);
        //    if (res.height == Screen.height
        //        && res.width == Screen.width)
        //    {
        //        currentResolutionIdx = resolutionsList.Count - 1;
        //    }
        //}
        //resolutionDropdown.ClearOptions();
        //resolutionDropdown.AddOptions(resolutionsList);
        //resolutionDropdown.value = currentResolutionIdx;
        //resolutionDropdown.RefreshShownValue();

        //fullscreenToggle.isOn = Screen.fullScreen;
    }

    void Update()
    {
    }

    public void StartGame()
    {
    }

    public void QuitGame()
    {
    }

    public void StartPlanning()
    {
        isPlanning = true;

        PlanningUI.SetActive(true);
    }

    public void StopPlanning()
    {
        isPlanning = false;

        PlanningUI.SetActive(false);
    }

    public void PlanningChangeSelectedEntry(int dir)
    {
        planningEntries[currentEntryIdx].GetComponent<PlanningEntry>().SetFocused(false);
        currentEntryIdx = Mathf.Clamp(currentEntryIdx + dir, 0, planningEntries.Count - 1);
        planningEntries[currentEntryIdx].GetComponent<PlanningEntry>().SetFocused(true);
        //PlanningBugInfo.text = bm.openedBugs[currentEntryIdx].GetDescription();
    }

    public void PlanningChangeEntryState()
    {
        planningEntries[currentEntryIdx].GetComponent<PlanningEntry>().SetState("");
    }

    public void MuteSound()
    {
        float volume = 0f;
        audioMixer.GetFloat("masterVolume", out volume);
        volume = Mathf.Abs(volume) - 80;
        audioMixer.SetFloat("masterVolume", volume);
    }

    // Settings

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
        //FindObjectOfType<AudioManager>().PlayClip("Shot");
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        Debug.Log(QualitySettings.GetQualityLevel());
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
    // Settings END
}
