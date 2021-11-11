using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugSpaceSkip : Bug
{
    public BugSpaceSkip(EBugState state = EBugState.Waiting)
    {
        bugName = "Skip Space";
        bugDesc = "Move by increment, not physics";
        bugType = EBugType.Silent;
        SetState(state);
    }
}
