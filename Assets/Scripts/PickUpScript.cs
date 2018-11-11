using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class PickUpScript : MonoBehaviour {
	public float speedX;
	public float speedY;

	private GameObject _camera;

	void Start()
	{
		_camera = Camera.main.gameObject;
		
		int rotation = Random.Range (0, 359);
		speedX = _camera.GetComponent<CameraFollower> ().speed
			* Mathf.Sin (Mathf.Deg2Rad * rotation);
		speedY = speedY = _camera.GetComponent<CameraFollower> ().speed 
			+ _camera.GetComponent<CameraFollower> ().speed
			* Mathf.Cos (Mathf.Deg2Rad * rotation);
	}

	void FixedUpdate(){
		gameObject.transform.position += new Vector3 (
			speedX * Time.deltaTime,
			speedY * Time.deltaTime,
			0);
	}
	
	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.CompareTag ("Player")) {
			DoPickupAction(col.gameObject);
			Destroy(gameObject);
		} else if (col.gameObject.CompareTag("Border")){
			if (col.gameObject.name.Equals ("Top_Border")) {
				speedY = _camera.GetComponent<CameraFollower> ().speed * 2 - speedY;
			} else if (col.gameObject.name.Equals ("Bottom_Border")) {
				speedY = _camera.GetComponent<CameraFollower> ().speed * 2 - speedY;
			} else {
				speedX = -speedX;
			}
		}
	}

	protected virtual void DoPickupAction(GameObject player) {}
}
