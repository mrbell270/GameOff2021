using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupBug : Pickup
{
    public EBugType bugType;
    // Start is called before the first frame update
    void Start()
    {
        pickupType = EPickupType.Bug;
    }
}
