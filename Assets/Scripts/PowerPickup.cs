using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerPickup : PickUpScript {
    protected override void DoPickupAction(GameObject player)
    {
        player.GetComponent<PlayerBehavior>().UpgradeBullets();
    }
}
