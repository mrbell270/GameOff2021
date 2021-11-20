using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatorPlatform : Activator
{
    [SerializeField]
    bool isOneWay = true;
    [SerializeField]
    float waitTimer = 0.5f;
    [SerializeField]
    [Range(1f, 10f)]
    float movementSpeed = 5f;
    [SerializeField]
    List<Vector2> trajectory;
    int currentPosition;
    
    bool isBusy = false;
    Rigidbody2D rb2d;
    Vector3 _velocity = Vector3.zero;
    float movementSmoothing = .05f;

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        if (trajectory.Count == 0)
        {
            trajectory.Add(transform.position);
        }
        currentPosition = 0;
        isBusy = false;
    }

    private void Update()
    {
        MoveLoop();
    }

    public override void SetState(EActivatorState terminalState, bool verbose = false)
    {
        activatorState = isOneWay ? EActivatorState.Inactive : terminalState;
        if (isOneWay)
        {
            StartCoroutine(MoveToNextPoint());
        }
    }

    void MoveLoop()
    {
        if (!isBusy && activatorState.Equals(EActivatorState.Active))
        {
            MoveToNextPoint();
        }
    }

    IEnumerator MoveToNextPoint()
    {
        isBusy = true;
        bool isMoving = true;
        currentPosition = (currentPosition + 1);
        if (currentPosition >= trajectory.Count)
        {
            currentPosition -= trajectory.Count;
        }
        while (isMoving && activatorState.Equals(EActivatorState.Active))
        {
            Vector2 direction = trajectory[currentPosition] - (Vector2)transform.position;
            Vector3 targetVelocity = direction.normalized * movementSpeed;
            rb2d.velocity = Vector3.SmoothDamp(rb2d.velocity, targetVelocity, ref _velocity, movementSmoothing);
            if (direction.sqrMagnitude <= 0.0001)
            {
                isMoving = false;
            }
            yield return null;
        }
        WaitFor();
    }

    IEnumerator WaitFor()
    {
        yield return new WaitForSeconds(waitTimer);
        isBusy = false;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        for (int i = 1; i < trajectory.Count; i++)
        {
            Gizmos.DrawLine(trajectory[i - 1], trajectory[i]);
        }
        if (!isOneWay)
        {
            Gizmos.DrawLine(trajectory[trajectory.Count - 1], trajectory[0]);
        }
    }
}
