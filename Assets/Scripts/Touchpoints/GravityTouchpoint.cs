using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityTouchpoint : BasicTouchpoint
{
    public float GravitationalConst;
    
    public override void ActOnPlayer(GameObject player, Vector2 touchpointToPlayer)
    {
        touchpointToPlayer *= -1;
        if (touchpointToPlayer.magnitude <= MaxRange && touchpointToPlayer.magnitude >= MinRange)
            player.GetComponent<Rigidbody2D>().AddForce(GravitationalConst / (touchpointToPlayer.magnitude + 0.2f) * touchpointToPlayer.normalized, ForceMode2D.Force);
    }

    public override void ActOnEnemy(GameObject enemy, Vector2 touchpointToEnemy) {}
    
    public override float CalculateLifetime(float lifetime)
    {
        return 1;
    }
}
