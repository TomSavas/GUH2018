using UnityEngine;

public class MouseTouchpointSpawner : MonoBehaviour
{
	public GameObject TouchpointPrefab;

	public void Update()
	{
		if(Input.GetMouseButtonDown(0))
            Instantiate(TouchpointPrefab, Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity);
	}
}
