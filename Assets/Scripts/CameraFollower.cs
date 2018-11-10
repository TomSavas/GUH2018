using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
	public bool enabled;
	public float speed;
	private bool changingSpeed = false;
	public float acceleration;

	private void FixedUpdate () {
		if(enabled)
            transform.position += new Vector3 (0, Time.deltaTime * speed);
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
