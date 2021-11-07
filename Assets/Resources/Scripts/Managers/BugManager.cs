using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugManager : MonoBehaviour
{
    static BugManager instance;
    public static BugManager GetInstance()
    {
        return instance;
    }

    [Header("Bugs Info")]
    List<Bug> allBugs;
    public List<Bug> availBugs;

    public int bugSlotAmountAvail;

    [Header("Collision")]
    [SerializeField]
    PseudoGroundManager pseudoGroundManager;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        allBugs = new List<Bug>();
        availBugs = new List<Bug>();

        bugSlotAmountAvail = 2;
        AddBug(new BugSpaceSkip());
        AddBug(new BugGravity());
        AddBug(new BugCollision());
    }

    public void ChooseBug(int bugNum)
    {
        if (bugSlotAmountAvail > 0 && availBugs.Count > bugNum)
        {
            Bug bug = availBugs[bugNum];
            if (bug.GetState() != EBugState.Loaded)
            {
                bug.SetState(EBugState.Loaded);
                bugSlotAmountAvail--;
                ApplyBug(bug.GetType());
            }
        }
        else
        {
            Debug.Log("Opened Slots = " + bugSlotAmountAvail);
        }
    }

    public void UnchooseBug(int bugNum)
    {
        if (availBugs.Count > bugNum)
        {
            Bug bug = availBugs[bugNum];
            if (bug.GetState() != EBugState.Waiting)
            {
                bug.SetState(EBugState.Waiting);
                bugSlotAmountAvail++;
                RevertBug(bug.GetType());
            }
        }
    }

    void AddBug(Bug bug, EBugState state = EBugState.Waiting)
    {
        bug.SetState(state);
        availBugs.Add(bug);
    }

    void ApplyBug(EBugType type)
    {
        Debug.Log(type.ToString() + " applied");
        switch (type) {
            case (EBugType.Collision):
                Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("PseudoGround"), true);
                pseudoGroundManager.SetVisual(true);
                break;
            default:
                Debug.Log("NOTE: No special actions for this bug!");
                break;
        }
    }
    void RevertBug(EBugType type)
    {
        Debug.Log(type.ToString() + " reverted");
        switch (type)
        {
            case (EBugType.Collision):
                Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("PseudoGround"), false);
                pseudoGroundManager.SetVisual(false);
                break;
            default:
                Debug.Log("NOTE: No special actions for this bug!");
                break;
        }
    }
}
