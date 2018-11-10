using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnPickUps : MonoBehaviour {

	public int spawnsPerMinute;
	public GameObject pickUp;
	private bool spawnedYet = false;

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
		return new Vector3 (0, 0, 0);
	}

}
