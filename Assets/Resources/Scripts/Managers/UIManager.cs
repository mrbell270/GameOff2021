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

public class UIManager : MonoBehaviour
{
    private static UIManager instance;
    public static UIManager GetInstance()
    {
        return instance;
    }


    [Header("Main")]
    EventSystem eventSystem;

    [Header("Planning Screen")]
    [SerializeField]
    GameObject PlanningUI;
    [SerializeField]
    TextMeshProUGUI PlanningBugInfo;
    [SerializeField]
    GameObject EntryTemplate;
    List<GameObject> planningEntries = new List<GameObject>();
    int currentEntryIdx;

    [Header("UI State")]
    bool isPlanning;

    [Header("Sound")]
    [SerializeField]
    static AudioMixer audioMixer;

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
}
