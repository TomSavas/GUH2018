using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {
	public float speed;

	private GameObject _player;

	private void Start() {
		_player = GameObject.FindGameObjectWithTag ("Player");
	}	

	private void FixedUpdate () {
		float distance = Mathf.Sqrt (
			Mathf.Pow((_player.transform.position.x - transform.position.x), 2) + 
			Mathf.Pow((_player.transform.position.y - 2 - transform.position.y), 2));
		float sinA = (_player.transform.position.x - transform.position.x) /
			(distance);
		float cosA = (_player.transform.position.y - 2 - transform.position.y) /
			(distance);
		float speedX = speed * sinA * Time.deltaTime;
		float speedY = (Camera.main.GetComponent<CameraFollower>().speed + speed * cosA) * Time.deltaTime;
		transform.position += 
			new Vector3 (speedX, speedY, 0);
	}
}
