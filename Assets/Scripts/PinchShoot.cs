using Leap.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinchShoot : PinchDetector
{

    public HandModelBase hand;
    public GameObject Player;

    // Use this for initialization
    void Start()
    {
        HandModel = hand;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        if (DidStartPinch)
        {
            Player.GetComponent<PlayerBehavior>().Shoot();
        }
    }

    protected override void ensureUpToDate()
    {
        base.ensureUpToDate();
    }
}
