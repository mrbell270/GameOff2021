using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    void SelfDestroy()
    {
        Destroy(gameObject);
    }

    public void SetGravity(bool enabled)
    {
        GetComponent<Rigidbody2D>().gravityScale = enabled ? 1 : 3;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Player got hit
        }

        SelfDestroy();
    }
}
