using System.Collections.Generic;
using UnityEngine;

public class MouseTouchpointSpawner : MonoBehaviour
{
	public GameObject GravityPrefab;
	public GameObject PushPrefab;

	private Dictionary<int, GameObject> _touchpoints;

	public void Start()
	{
		_touchpoints = new Dictionary<int, GameObject>();
	}

	public void Update()
	{
		if (Input.GetMouseButtonDown(0) && !_touchpoints.ContainsKey(0))
		{
			var touchpoint = Instantiate(GravityPrefab, Camera.main.gameObject.transform, false);
			touchpoint.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			_touchpoints.Add(0, touchpoint);
		}
		else if(Input.GetMouseButtonUp(0) && _touchpoints.ContainsKey(0))
		{
			var touchpoint = _touchpoints[0];
			_touchpoints.Remove(0);
			Destroy(touchpoint);
		}
		
		if (Input.GetMouseButtonDown(2) && !_touchpoints.ContainsKey(2))
		{
			var touchpoint = Instantiate(PushPrefab, Camera.main.gameObject.transform, false);
			touchpoint.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			_touchpoints.Add(2, touchpoint);
		}
		else if(Input.GetMouseButtonUp(2) && _touchpoints.ContainsKey(2))
		{
			var touchpoint = _touchpoints[2];
			_touchpoints.Remove(2);
			Destroy(touchpoint);
		}
	}
}
