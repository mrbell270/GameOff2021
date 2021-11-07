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
    TextMeshProUGUI PlanningOpenedSlots;
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
        if (isPlanning)
        {
            PlanningOpenedSlots.text = bm.openSlotsAmount.ToString();
            for (int i=0; i<planningEntries.Count; i++)
            {             
                PlanningEntry pe = planningEntries[i].GetComponent<PlanningEntry>();
                Bug bug = bm.openedBugs[i];
                pe.SetName(bug.GetName());
                pe.SetState(bug.GetState().ToString());
            }
        }
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

        foreach (Bug bug in bm.openedBugs)
        {
            GameObject entry = Instantiate(EntryTemplate, EntryTemplate.transform.parent, false);
            PlanningEntry pe = entry.GetComponent<PlanningEntry>();
            pe.SetName(bug.GetName());
            pe.SetState(bug.GetState().ToString());
            pe.SetFocused(false);
            entry.SetActive(true);
            planningEntries.Add(entry);
        }
        currentEntryIdx = 0;
        PlanningChangeSelectedEntry(0);
        PlanningOpenedSlots.text = bm.openSlotsAmount.ToString();

        PlanningUI.SetActive(true);
    }

    public void StopPlanning()
    {
        isPlanning = false;

        PlanningUI.SetActive(false);

        foreach (GameObject entry in planningEntries)
        {
            Destroy(entry);
        }
        planningEntries.Clear();
    }

    public void PlanningChangeSelectedEntry(int dir)
    {
        planningEntries[currentEntryIdx].GetComponent<PlanningEntry>().SetFocused(false);
        currentEntryIdx = Mathf.Clamp(currentEntryIdx + dir, 0, planningEntries.Count - 1);
        planningEntries[currentEntryIdx].GetComponent<PlanningEntry>().SetFocused(true);
        PlanningBugInfo.text = bm.openedBugs[currentEntryIdx].GetDescription();
    }

    public void PlanningChangeEntryState()
    {
        EBugState curState = bm.openedBugs[currentEntryIdx].GetState();
        if (curState.Equals(EBugState.Loaded))
        {
            bm.UnchooseBug(currentEntryIdx);
        }
        else if (curState.Equals(EBugState.Waiting))
        {
            bm.ChooseBug(currentEntryIdx);
        }
        planningEntries[currentEntryIdx].GetComponent<PlanningEntry>().SetState(bm.openedBugs[currentEntryIdx].GetState().ToString());
        PlanningOpenedSlots.text = bm.openSlotsAmount.ToString();
    }

    public void MuteSound()
    {
        float volume = 0f;
        audioMixer.GetFloat("masterVolume", out volume);
        volume = Mathf.Abs(volume) - 80;
        audioMixer.SetFloat("masterVolume", volume);
    }
}
