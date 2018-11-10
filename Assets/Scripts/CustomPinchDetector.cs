using Leap.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomPinchDetector : PinchDetector {

    public HandModelBase hand;

	// Use this for initialization
	void Start () {
        HandModel = hand;
	}
	
	// Update is called once per frame
	void Update () {
        if (IsPinching) Debug.Log("valiooo");
	}

    protected override void ensureUpToDate()
    {
        base.ensureUpToDate();
    }
}
