using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terminal : MonoBehaviour
{
    [SerializeField]
    EActivatorState terminalState;
    [SerializeField]
    List<Activator> activators;

    private void Awake()
    {
        foreach (Activator activator in activators)
        {
            activator.SetState(terminalState);
        }
    }

    public void Use()
    {
        terminalState = (EActivatorState)(((int)terminalState + 1) % 2);
        foreach (Activator activator in activators)
        {
            activator.SetState(terminalState);
        }
    }
}
