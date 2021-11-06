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

    [Header("")]
    List<IBug> allBugs;
    public List<IBug> availBugs;
    public Dictionary<int, IBug> chosenBugs;

    int bugSlotAmountOpened;
    int bugSlotAmountAvail;



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
        allBugs = new List<IBug>();
        availBugs = new List<IBug>();
        chosenBugs = new Dictionary<int, IBug>();

        bugSlotAmountOpened = 1;
        bugSlotAmountAvail = 1;
        IBug b0 = new BugSpaceSkip();
        allBugs.Add(b0);
        availBugs.Add(b0);
        availBugs.Add(b0);
        availBugs.Add(b0);
        availBugs.Add(b0);
    }

    public void ChooseBug(int bugNum, int slotNum)
    {
        if (bugSlotAmountAvail > 0 && availBugs.Count > bugNum && !chosenBugs.ContainsKey(slotNum))
        {
            IBug b = availBugs[bugNum];
            if (!chosenBugs.ContainsValue(b))
            {
                chosenBugs.Add(slotNum, b);
                bugSlotAmountAvail--;
                b.ApplyEffects();
            }
        }
    }

    public void UnchooseBug(int slotNum)
    {
        if (chosenBugs.Count > slotNum)
        {
            IBug b = chosenBugs[slotNum];
            chosenBugs.Remove(slotNum);
            bugSlotAmountAvail++;
            b.RevertEffects();
        }
    }
}
