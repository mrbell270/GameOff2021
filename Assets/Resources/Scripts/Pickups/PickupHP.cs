
public class PickupHP : Pickup
{
    public int hp = 50;
    void Start()
    {
        pickupType = EPickupType.Health;
    }
}

