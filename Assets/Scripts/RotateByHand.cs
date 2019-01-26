using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap.Unity;

public class RotateByHand : MonoBehaviour {

    public HandModelBase hand;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        Leap.LeapQuaternion lq = hand.GetLeapHand().Rotation;
        float z = new Quaternion(lq.x, lq.y, lq.z, lq.w).eulerAngles.z;
        transform.rotation = Quaternion.Euler(0, 0, z);
    }
}
