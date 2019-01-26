using Leap.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinchGravity : PinchDetector {

    public HandModelBase hand;
    public GameObject TouchpointPrefab;
    public GameObject TouchpointObject;
    public GameObject BlackHole;

    // Use this for initialization
    void Start () {
        HandModel = hand;
	}

    // Update is called once per frame
    protected override void Update () {
        base.Update();
        if (!IsPinching) {
            BlackHole.transform.position = hand.GetLeapHand().GetPinchPosition();
        }
        
        if (DidStartPinch) {
            TouchpointObject = Instantiate(TouchpointPrefab, Camera.main.transform, false);
            TouchpointObject.transform.position = BlackHole.transform.position;
        }

        if (DidEndPinch) {
            Destroy(TouchpointObject);
        }
	}

    protected override void ensureUpToDate()
    {
        base.ensureUpToDate();
    }
}
