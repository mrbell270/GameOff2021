using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terminal : MonoBehaviour
{
    [SerializeField]
    EActivatorState terminalState;
    [SerializeField]
    List<Activator> activators;
    [SerializeField]
    List<Sprite> sprites;

    private void Start()
    {
        foreach (Activator activator in activators)
        {
            activator.SetState(terminalState);
        }
        GetComponent<SpriteRenderer>().sprite = sprites[(int)terminalState];
    }

    public void Use()
    {
        terminalState = (EActivatorState)(((int)terminalState + 1) % 2);
        GetComponent<SpriteRenderer>().sprite = sprites[(int)terminalState];
        foreach (Activator activator in activators)
        {
            activator.SetState(terminalState);
        }
    }

    public void ShowLines(bool enabled)
    {
        foreach(Activator activator in activators)
        {
            activator.ShowLine(transform.position, enabled);
        }
    }
}
