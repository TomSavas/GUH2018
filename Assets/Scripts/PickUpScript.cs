using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class PickUpScript : MonoBehaviour {


	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.CompareTag ("Player")) {
			Debug.Log ("Player");
		}
	}
}
