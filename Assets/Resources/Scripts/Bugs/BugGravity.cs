using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugGravity : Bug
{
    public BugGravity(EBugState state = EBugState.Waiting)
    {
        bugName = "Gravity Change";
        bugDesc = "Move with no gravity";
        bugType = EBugType.Gravity;
        SetState(state);
    }
}
