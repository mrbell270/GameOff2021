using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BugManager : MonoBehaviour
{
    static BugManager instance;
    public static BugManager GetInstance()
    {
        return instance;
    }

    [Header("Bugs Info")]
    public List<Bug> openedBugs;

    public int openSlotsAmount;

    [FoldoutGroup("Collision", expanded: false)]
    [SerializeField]
    PseudoGroundManager pseudoGroundManager;
    [FoldoutGroup("Collision")]
    [SerializeField]
    UnityEvent OnCollisionApply;
    [FoldoutGroup("Collision")]
    [SerializeField]
    UnityEvent OnCollisionRevert;

    [FoldoutGroup("Gravity", expanded: false)]
    [FoldoutGroup("Gravity")]
    [SerializeField]
    UnityEvent OnGravityApply;
    [FoldoutGroup("Gravity")]
    [SerializeField]
    UnityEvent OnGravityRevert;


    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        instance = this;

        // Collision Additional Events
        OnCollisionApply.AddListener(() => Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("PseudoGround"), true));
        OnCollisionApply.AddListener(() => Player.GetInstance().movementController.RemoveGroundLayer(LayerMask.NameToLayer("PseudoGround")));

        OnCollisionRevert.AddListener(() => Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("PseudoGround"), false));
        OnCollisionRevert.AddListener(() => Player.GetInstance().movementController.AddGroundLayer(LayerMask.NameToLayer("PseudoGround")));

        // Gravity Additional Events
    }

    // Start is called before the first frame update
    void Start()
    {
        openSlotsAmount = 0;
        openedBugs = new List<Bug>();

        //openSlotsAmount = 2;
        //AddBug(new BugSpaceSkip());
        //AddBug(new BugGravity());
        //AddBug(new BugCollision());
    }

    public void ChooseBug(int bugNum)
    {
        if (openSlotsAmount > 0 && openedBugs.Count > bugNum)
        {
            Bug bug = openedBugs[bugNum];
            if (bug.GetState() != EBugState.Loaded)
            {
                bug.SetState(EBugState.Loaded);
                openSlotsAmount--;
                ApplyBug(bug.GetBugType());
            }
        }
        else
        {
            Debug.Log("Opened Slots = " + openSlotsAmount);
        }
    }

    public void UnchooseBug(int bugNum)
    {
        if (openedBugs.Count > bugNum)
        {
            Bug bug = openedBugs[bugNum];
            if (bug.GetState() != EBugState.Waiting)
            {
                bug.SetState(EBugState.Waiting);
                openSlotsAmount++;
                RevertBug(bug.GetBugType());
            }
        }
    }

    public void AddBug(Bug bug, EBugState state = EBugState.Waiting)
    {
        bug.SetState(state);
        openedBugs.Add(bug);
    }

    public void AddBug(EBugType bugType)
    {
        Bug bug = null;
        switch (bugType)
        {
            case (EBugType.Collision):
                bug = new BugCollision();
                break;
            case (EBugType.Gravity):
                bug = new BugGravity();
                break;
            case (EBugType.Skip):
                bug = new BugSpaceSkip();
                break;
        }
        if (bug != null)
        {
            AddBug(bug);
        }
    }

    public void AddSlot()
    {
        openSlotsAmount++;
    }

    void ApplyBug(EBugType type)
    {
        Debug.Log(type.ToString() + " applied");
        switch (type) {
            case (EBugType.Collision):
                OnCollisionApply?.Invoke();
                break;
            case (EBugType.Gravity):
                OnGravityApply?.Invoke();
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
                OnCollisionRevert?.Invoke();
                break;
            case (EBugType.Gravity):
                OnGravityRevert?.Invoke();
                break;
            default:
                Debug.Log("NOTE: No special actions for this bug!");
                break;
        }
    }

    private void LeaveRoom()
    {
        for(int i=0; i<openedBugs.Count; i++)
        {
            UnchooseBug(i);
        }
    }
}
