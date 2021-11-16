using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Activator : MonoBehaviour
{
    public EActivatorState activatorState;
    public abstract void SetState(EActivatorState terminalState, bool verbose=false);
}
