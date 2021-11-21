using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Activator : MonoBehaviour
{
    public EActivatorState activatorState;
    protected LineRenderer lr;
    public abstract void SetState(EActivatorState terminalState, bool verbose=false);

    public void ShowLine(Vector2 pointTo, bool enabled)
    {
        lr.SetPosition(0, transform.position);
        lr.SetPosition(1, pointTo);
        lr.enabled = enabled;
    }
}
