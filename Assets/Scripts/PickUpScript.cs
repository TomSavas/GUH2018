using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class PickUpScript : MonoBehaviour {
	public float speedX;
	public float speedY;
	public GameObject camera;

	void Start(){
		int rotation = Random.Range (0, 359);
		speedX = camera.GetComponent<CameraFollower> ().speed
			* Mathf.Sin (Mathf.Deg2Rad * rotation);
		speedY = speedY = camera.GetComponent<CameraFollower> ().speed 
			+ camera.GetComponent<CameraFollower> ().speed
			* Mathf.Cos (Mathf.Deg2Rad * rotation);
	}

	void FixedUpdate(){
		gameObject.transform.position += new Vector3 (
			speedX * Time.deltaTime,
			speedY * Time.deltaTime,
			0);
	}
	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.CompareTag ("Player")) {
			Debug.Log ("Player");
		}else if (col.gameObject.CompareTag("Border")){
			if (col.gameObject.name.Equals ("Top_Border")) {
				speedY = camera.GetComponent<CameraFollower> ().speed * 2 - speedY;
			} else if (col.gameObject.name.Equals ("Bottom_Border")) {
				speedY = camera.GetComponent<CameraFollower> ().speed * 2 - speedY;
			} else {
				speedX = -speedX;
			}
		}
	}
}
