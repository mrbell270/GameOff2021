using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : MonoBehaviour
{
    [SerializeField]
    List<Vector2> trajectory;

    [SerializeField]
    GameObject fov;
    [SerializeField]
    LayerMask playerLayer;

    bool isLookingRight = true;
    
    [SerializeField]
    [Range(2f, 6f)]
    float visionRadius = 2f;
    [SerializeField]
    float minVisionRadius = 2f;
    [SerializeField]
    float maxVisionRadius = 6f;
    [SerializeField]
    float suspicionIncreaseTime = 2f;
    [SerializeField]
    float suspicionDecreaseTime = 2f;
    [SerializeField]
    float alarmTimeout = 3f;

    [SerializeField]
    List<Vector2> rays;



    void Start()
    {
    }


    void Update()
    {
        fov.transform.localScale = Vector3.one * (visionRadius / minVisionRadius);
    }

    private void FixedUpdate()
    {
        LookForPlayer();
        Move();
    }

    void Move()
    {
        
    }

    void LookForPlayer()
    {
        foreach (Vector2 ray in rays)
        {
            RaycastHit2D hit = Physics2D.Raycast(fov.transform.position, ray, visionRadius, playerLayer);
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


    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        for (int i = 0; i < trajectory.Count; i++)
        {
            Gizmos.DrawLine(((i==0) ? (Vector2)transform.position : trajectory[i-1]), trajectory[i]);
        }
    }
}
