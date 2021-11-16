using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using System;
using UnityEngine.Events;

public class Guard : MonoBehaviour
{
    [FoldoutGroup("Movement")]
    [SerializeField]
    GuardController controller;
    [FoldoutGroup("Movement")]
    [SerializeField]
    float waitTimer = 1.5f;
    [FoldoutGroup("Movement")]
    [SerializeField]
    float pointError = 0.5f;
    [FoldoutGroup("Movement")]
    int currentPoint = 0;
    [FoldoutGroup("Movement")]
    bool isWaiting = false;
    [FoldoutGroup("Movement")]
    [SerializeField]
    List<Vector2> trajectory;

    [FoldoutGroup("Guarding")]
    [SerializeField]
    GameObject raysVisuals;
    [FoldoutGroup("Guarding")]
    [SerializeField]
    LayerMask playerLayer;
    [FoldoutGroup("Guarding")]
    [SerializeField]
    List<Vector2> rays;

    [FoldoutGroup("Guarding")]
    [SerializeField]
    [Range(2f, 6f)]
    float visionRadius = 2f;
    [FoldoutGroup("Guarding")]
    [SerializeField]
    float minVisionRadius = 2f;
    [FoldoutGroup("Guarding")]
    [SerializeField]
    float maxVisionRadius = 6f;
    [FoldoutGroup("Guarding")]
    [SerializeField]
    float suspicionIncreaseTime = 2f;
    [FoldoutGroup("Guarding")]
    [SerializeField]
    float suspicionDecreaseTime = 2f;
    [FoldoutGroup("Guarding")]
    [SerializeField]
    float alarmTimeout = 3f;

    //UnityAction WaitAction;


    void Start()
    {
        controller = GetComponent<GuardController>();
        //WaitAction += Wait;
        //controller.OnTurnEvent.AddListener(WaitAction);
    }


    void Update()
    {
        raysVisuals.transform.localScale = Vector3.one * (visionRadius / minVisionRadius);
    }

    private void FixedUpdate()
    {
        LookForPlayer();
        Move();
    }

    void LookForPlayer()
    {
        foreach (Vector2 ray in rays)
        {
            RaycastHit2D hit = Physics2D.Raycast(raysVisuals.transform.position, ray, visionRadius, playerLayer);
            if (hit.collider != null)
            {
                PlayerHit();
                break;
            }
        }
    }

    void Move()
    {
        if (!isWaiting)
        {
            controller.SwitchMovement(true, 0);
        }
    }

     public void Wait()
    {
        isWaiting = true;
        StartCoroutine(WaitForTimer(waitTimer));
    }

    IEnumerator WaitForTimer(float waitTimer)
    {
        yield return new WaitForSeconds(waitTimer);
        isWaiting = false;
    }

    void PlayerHit()
    {
        Debug.Log("Hit");
    }


    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        for (int i = 0; i < trajectory.Count; i++)
        {
            Gizmos.DrawLine(((i==0) ? (Vector2)transform.position : trajectory[i-1]), trajectory[i]);
        }
    }
}
