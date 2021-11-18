using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using System;
using UnityEngine.Events;

public class Guard : MonoBehaviour
{
    [VerticalGroup("Movement")]
    [SerializeField]
    GuardController controller;
    [VerticalGroup("Movement")]
    [SerializeField]
    bool isFacingRight = true;
    [VerticalGroup("Movement")]
    [SerializeField]
    bool flipBeforeWait = true;

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
    float suspicionIncreaseTime = 0.2f;
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

    void PlayerHit()
    {
        Debug.Log("Hit");
    }
}
