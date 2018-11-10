using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour {
	public float speed;
	private bool changingSpeed;
	public float acceleration;
	// Use this for initialization
	void Start () {
		changingSpeed = false;
	}
	
	// Update is called once per frame
	private void FixedUpdate () {
		transform.position += new Vector3 (0, Time.deltaTime * speed);
		if (transform.position.y > 50) {
			SetSpeed (-10);
		} else if (transform.position.y < 0) {
			SetSpeed (10);
		}
	}
	public void SetSpeed(float newSpeed)
	{
		if (!changingSpeed) {
			StartCoroutine (SmoothMove (newSpeed));
			changingSpeed = true;
		}
	}
	public IEnumerator SmoothMove(float newSpeed)
	{
		bool isNewSpeedHigher = newSpeed > speed;

		while ((isNewSpeedHigher && speed < newSpeed) || speed > newSpeed)
		{
			speed += acceleration * (isNewSpeedHigher ? 1 : -1);
			yield return null;
		}
		changingSpeed = false;
	}
}
