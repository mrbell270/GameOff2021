using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BugCollision : Bug
{
    public BugCollision(EBugState state = EBugState.Waiting)
    {
        bugName = "Collision";
        bugDesc = "Some objects have buggy colliders";
        bugType = EBugType.Small;
        SetState(state);
    }
}
