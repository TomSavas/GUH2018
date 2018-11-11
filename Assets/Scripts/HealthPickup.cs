using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : PickUpScript {
    protected override void DoPickupAction(GameObject player)
    {
        player.GetComponent<PlayerBehavior>().IncrementHealth();
    }
}
