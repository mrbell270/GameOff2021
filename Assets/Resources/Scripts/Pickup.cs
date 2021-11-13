using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public EPickupType pickupType;
    bool pickupDone = false;

    void SelfDestroy()
    {
        // TODO
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!pickupDone)
        {
            pickupDone = true;
            if (collision.CompareTag("Player"))
            {
                //Player.GetInstance().GetPickup(this);
                SelfDestroy();
            }
            Invoke("ResetPickup", 0.2f);
        }
    }

    private void ResetPickup()
    {
        pickupDone = false;
    }
}
