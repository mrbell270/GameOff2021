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
    [SerializeField]
    BugManager bm;

    [Header("Planning Screen")]
    [SerializeField]
    GameObject PlanningUI;
    [SerializeField]
    GameObject EntryTemplate;
    List<GameObject> planningEntries = new List<GameObject>();
    int currentEntryIdx;

    [Header("Death Screen")]

    [Header("Sound")]
    [SerializeField]
    AudioMixer audioMixer;

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
        foreach(IBug bug in bm.availBugs)
        {
            GameObject entry = Instantiate(EntryTemplate, EntryTemplate.transform.parent, false);
            PlanningEntry pe = entry.GetComponent<PlanningEntry>();
            pe.SetName(bug.GetName());
            pe.SetState("Ready");
            pe.SetFocused(false);
            entry.SetActive(true);
            planningEntries.Add(entry);
        }
        currentEntryIdx = 0;
        planningEntries[currentEntryIdx].GetComponent<PlanningEntry>().SetFocused(true);
        PlanningUI.SetActive(true);
    }

    public void StopPlanning()
    {
        PlanningUI.SetActive(false);

        foreach (GameObject entry in planningEntries)
        {
            Destroy(entry);
        }
        planningEntries.Clear();
    }

    public void MuteSound()
    {
        float volume = 0f;
        audioMixer.GetFloat("masterVolume", out volume);
        volume = Mathf.Abs(volume) - 80;
        audioMixer.SetFloat("masterVolume", volume);
    }
}
