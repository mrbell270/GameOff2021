using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class Bug
{
    protected string bugName;
    protected string bugDesc;
    protected EBugType bugType;
    private EBugState bugState;
    public EBugType GetType() { return bugType; }
    public string GetName() { return bugName; }
    public string GetDescription() { return bugDesc; }
    public EBugState GetState() { return bugState; }
    public void SetState(EBugState value) { bugState = value; }

}
