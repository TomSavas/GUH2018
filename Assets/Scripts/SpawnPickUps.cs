using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class SpawnPickUps : MonoBehaviour {

	public int SpawnsPerMinute;
	public List<GameObject> Pickups;
	public bool Enabled;
	
	private bool spawnedYet = false;

	void Update(){
		if (Enabled && Pickups.Count != 0)
		{
            int time = (Mathf.RoundToInt(Time.time)) % (60/SpawnsPerMinute);
			
            if (!spawnedYet) {
                int randomedTime = Random.Range (1, 60/SpawnsPerMinute);
                if (time >= randomedTime) {
                    Instantiate (GetPickup(), GenerateNewPosition(), Quaternion.identity);
                    spawnedYet = true;
                }
	            
            }
            if (time == 0) {
                spawnedYet = false;
            }
		}
	}
	
	private GameObject GetPickup()
	{
		return Pickups[Random.Range(0, Pickups.Count)];
	}
	
	private Vector3 GenerateNewPosition(){
		float y = Random.Range (Camera.main.transform.position.y - 4.5f, Camera.main.transform.position.y + 4.5f);
		float x = Random.Range (-3.5f, 3.5f);
		return new Vector3 (x, y, 0);
	}

}
