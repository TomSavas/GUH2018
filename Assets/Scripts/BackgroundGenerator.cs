using System.Collections;
using System.Collections.Generic;
using System.Security.Permissions;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class BackgroundGenerator : MonoBehaviour
{
	public GameObject Star;
	public GameObject Earth;
	public GameObject Neptune;
	public float StarFrequency;
	public float PlanetFrequency;
	public bool Enabled;

	private float _sinceLastStarSpawn;
	private float _sinceLastPlanetSpawn;

	private void Start()
	{
		for(int i = 0; i < 200; i++) GenerateItems();
	}
	
	private void Update ()
	{
		if(Enabled)
			GenerateItemsAhead();
	}

	private void GenerateItems()
	{
		if (_sinceLastStarSpawn <= 0)
		{
			_sinceLastStarSpawn = 1/StarFrequency;
			var star = Instantiate(Star, GenerateCoord(), Quaternion.identity);
			Destroy(star, 20f);
		}
		else
		{
			_sinceLastStarSpawn -= Time.deltaTime;
		}

		if (_sinceLastPlanetSpawn <= 0)
		{
			_sinceLastPlanetSpawn = 1/PlanetFrequency;
			GameObject item;
			if(Random.Range(0, 2) == 0) 
                item = Instantiate(Earth, GenerateCoord(), Quaternion.identity);
			else 
                item = Instantiate(Neptune, GenerateCoord(), Quaternion.identity);
			Destroy(item, 20f);
		}
		else
		{
			_sinceLastPlanetSpawn -= Time.deltaTime;
		}
	}
	
	private void GenerateItemsAhead()
	{
		if (_sinceLastStarSpawn <= 0)
		{
			_sinceLastStarSpawn = 1/StarFrequency;
			var star = Instantiate(Star, GenerateAheadCoord(), Quaternion.identity);
			Destroy(star, 20f);
		}
		else
		{
			_sinceLastStarSpawn -= Time.deltaTime;
		}

		if (_sinceLastPlanetSpawn <= 0)
		{
			_sinceLastPlanetSpawn = 1/PlanetFrequency;
			GameObject item;
			if(Random.Range(0, 2) == 0) 
                item = Instantiate(Earth, GenerateAheadCoord(), Quaternion.identity);
			else 
                item = Instantiate(Neptune, GenerateAheadCoord(), Quaternion.identity);
			Destroy(item, 20f);
		}
		else
		{
			_sinceLastPlanetSpawn -= Time.deltaTime;
		}
	}

	private Vector2 GenerateCoord()
	{
		return new Vector2(GenerateXCoord(), GenerateYCoord());
	}
	
    private float GenerateXCoord()
    {
        return Camera.main.ViewportToWorldPoint(new Vector3(Random.Range(0f, 1f), 0, 0)).x;
    }
	
    private float GenerateYCoord()
    {
        return Camera.main.ViewportToWorldPoint(new Vector3(0, Random.Range(0f, 1f), 0)).y;
    }
	
	private Vector2 GenerateAheadCoord()
	{
		return new Vector2(GenerateXCoord(), GenerateAheadYCoord());
	}
	
    private float GenerateAheadYCoord()
    {
	    return Camera.main.ViewportToWorldPoint(new Vector3(0, Random.Range(0f, 1f), 0)).y +
	           Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0)).y * 2f;
    }
}
