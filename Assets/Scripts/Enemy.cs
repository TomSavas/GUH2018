using UnityEngine;

public class Enemy : MonoBehaviour
{
	public int ShotsPerMinute;
	public GameObject BulletPrefab;
	public float Speed;

	private float _shootingPeriod;
	private float _lastShotTime;
	
	private void Start()
	{
		_shootingPeriod = 60 / ShotsPerMinute;
		_lastShotTime = Time.time;
	}

	private void Update () {
		if (Time.time > _lastShotTime + _shootingPeriod)
		{
			Shoot();
			_lastShotTime = Time.time;
		}
	}

	private void Shoot()
	{
		var bullet = Instantiate(BulletPrefab, Camera.main.transform);
		bullet.transform.position = transform.position;
		bullet.GetComponent<Rigidbody2D>().AddForce(Vector2.up * Speed, ForceMode2D.Impulse);
	}
}
