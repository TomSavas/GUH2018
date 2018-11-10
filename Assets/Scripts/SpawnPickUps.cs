using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnPickUps : MonoBehaviour {

	public int spawnsPerMinute;
	public GameObject pickUp;
	private bool spawnedYet = false;
	public GameObject camera;

	void Update(){
		int time = (Mathf.RoundToInt(Time.time)) % (60/spawnsPerMinute);
		if (!spawnedYet) {
			int randomedTime = Random.Range (1, 60/spawnsPerMinute - 1);
			if (time >= randomedTime) {
				Instantiate (pickUp, generateNewPosition(), Quaternion.identity);
				spawnedYet = true;
			}
		}
		if (time == 0) {
			spawnedYet = false;
		}
	}
	Vector3 generateNewPosition(){
		float y = Random.Range (camera.transform.position.y - 4.5f, camera.transform.position.y + 4.5f);
		float x = Random.Range (-3.5f, 3.5f);
		return new Vector3 (x, y, 0);
	}

}
