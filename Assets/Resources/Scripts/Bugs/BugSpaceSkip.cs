using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugSpaceSkip : IBug
{
    public void ApplyEffects()
    {
        Debug.Log("BugSpaceSkip Applied");
    }

    public void RevertEffects()
    {
        Debug.Log("BugSpaceSkip reverted");
    }

    public string GetDescription()
    {
        return "SpaceSkip Bug";
    }

    public string GetName()
    {
        return "BugSpaceSkip";
    }
}
