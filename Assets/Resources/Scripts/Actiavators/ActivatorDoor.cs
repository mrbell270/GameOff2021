using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatorDoor : Activator
{
    [SerializeField]
    bool isReversed = false;
    [SerializeField]
    [Range(0.05f, 3f)]
    float openningTimer = 1f;
    [SerializeField]
    [Range(0.05f, 3f)]
    float closingTimer = 0.2f;
    Vector3 standartScale;
    bool isClosed = true;

    void Awake()
    {
        lr = GetComponent<LineRenderer>();
        standartScale = new Vector3(1, 1, 1);
        ChangeState(activatorState);
    }

    public override void SetState(EActivatorState terminalState, bool verbose = false)
    {
        activatorState = isReversed ? (EActivatorState)(((int)terminalState + 1) % 2) : terminalState;
        ChangeState(activatorState);
    }

    void ChangeState(EActivatorState terminalState)
    {
        if (terminalState.Equals(EActivatorState.Active) && isClosed)
        {
            StartCoroutine(OpenDoor(openningTimer));
        }
        else if(terminalState.Equals(EActivatorState.Inactive) && !isClosed)
        {
            StartCoroutine(CloseDoor(closingTimer));
        }
    }

    IEnumerator OpenDoor(float timeToOpen)
    {
        float timeElapsed = 0f;
        while(timeElapsed < timeToOpen)
        {
            timeElapsed += Time.deltaTime;
            transform.localScale = Vector3.Lerp(standartScale, Vector3.zero, (timeElapsed/timeToOpen));
            yield return null;
        }
    }

    IEnumerator CloseDoor(float timeToClose)
    {
        float timeElapsed = 0f;
        while(timeElapsed < timeToClose)
        {
            timeElapsed += Time.deltaTime;
            transform.localScale = Vector3.Lerp(Vector3.zero, standartScale, (timeElapsed/timeToClose));
            yield return null;
        }
    }
}
