using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PlayerBehavior : MonoBehaviour
{
	public int Health;
	public float InvulnerabilityTime;
	public float BlinkHoldback;
	public GameObject BulletPrefab;
	public float BulletSpeed;
	public float FiringCooldownTime;
	public Vector2 ShootingPosition;
	public GameObject HealthDisplay1;
	public GameObject HealthDisplay2;
	public GameObject HealthDisplay3;
	
	private bool _invulnerable;
	private float _invulnerabilityTime;
	private SpriteRenderer _spriteRenderer;
	private bool _onCooldown;
	private float _cooldownTime;
	private float _blinkHoldback;
	private bool _transparent;
	private bool _upgraded;

	private void Start()
	{
		_spriteRenderer = GetComponent<SpriteRenderer>();
	}

	private void Update()
	{
		if (_invulnerable)
		{
			if (_invulnerabilityTime > 0)
			{
				_invulnerabilityTime -= Time.deltaTime;
				Blink();
			}
			else
			{
				_invulnerable = false;
				// Reset blinking
                _spriteRenderer.color = new Color(_spriteRenderer.color.r, _spriteRenderer.color.g, _spriteRenderer.color.b, 1f);
				_transparent = false;
			}
		}

		if (!_onCooldown)
		{
            if (Input.GetKey(KeyCode.Space))
            {
                Shoot();
                _onCooldown = true;
	            _cooldownTime = FiringCooldownTime;
            }
		}
		else
		{
			_cooldownTime -= Time.deltaTime;
			if (_cooldownTime < 0)
				_onCooldown = false;
		}

	}

	private void OnSceneGUI()
	{
		Handles.color = Color.blue;
		Handles.DrawWireCube(new Vector3(ShootingPosition.x, ShootingPosition.y, 0), Vector3.one);
	}

	public void ReceiveDamage()
	{
		if (!_invulnerable)
		{
			DecrementHealth();
			_invulnerable = true;
			_invulnerabilityTime = InvulnerabilityTime;
			if(Health == 0)
				Application.LoadLevel(Application.loadedLevel);
		}
	}

	private void Blink()
	{
		if (_blinkHoldback > 0f)
		{
			_blinkHoldback -= Time.deltaTime;
		}
		else
		{
			if (_transparent)
			{
                _spriteRenderer.color = new Color(_spriteRenderer.color.r, _spriteRenderer.color.g, _spriteRenderer.color.b, 1f);
				_transparent = false;
			}
			else
			{
                _spriteRenderer.color = new Color(_spriteRenderer.color.r, _spriteRenderer.color.g, _spriteRenderer.color.b, 0.5f);
				_transparent = true;
			}
			_blinkHoldback = BlinkHoldback;
		}
	}

	public void DecrementHealth()
	{
		if (Health > 0)
			Health -= 1;
		UpdateHealthDisplay();
	}

	public void IncrementHealth()
	{
		if (Health < 3)
			Health += 1;
		UpdateHealthDisplay();
	}

	public void UpdateHealthDisplay()
	{
        HealthDisplay1.SetActive(true);
        HealthDisplay2.SetActive(true);
        HealthDisplay3.SetActive(true);
		if (Health == 2)
		{
			HealthDisplay3.SetActive(false);
		} else if (Health == 1)
		{
			HealthDisplay3.SetActive(false);
			HealthDisplay2.SetActive(false);
		} else if (Health == 0)
		{
			HealthDisplay3.SetActive(false);
			HealthDisplay2.SetActive(false);
			HealthDisplay1.SetActive(false);
		}
	}

	public void Shoot()
	{
        var bullet = Instantiate(BulletPrefab, Camera.main.transform);
        bullet.transform.position = transform.position + transform.rotation * Vector2.up * -0.8f;
        bullet.GetComponent<Rigidbody2D>().AddForce(transform.rotation * -Vector2.up * BulletSpeed, ForceMode2D.Impulse);
		if (_upgraded)
		{
            bullet = Instantiate(BulletPrefab, Camera.main.transform);
            bullet.transform.position = transform.position + transform.rotation * Vector2.up * -0.8f;
            bullet.GetComponent<Rigidbody2D>().AddForce(transform.rotation * (-Vector2.up + Vector2.right)/2 * BulletSpeed, ForceMode2D.Impulse);
			
            bullet = Instantiate(BulletPrefab, Camera.main.transform);
            bullet.transform.position = transform.position + transform.rotation * Vector2.up * -0.8f;
            bullet.GetComponent<Rigidbody2D>().AddForce(transform.rotation * (-Vector2.up + Vector2.left)/2 * BulletSpeed, ForceMode2D.Impulse);
		}
	}

	public void UpgradeBullets()
	{
		_upgraded = true;
	}

	public void DowngradeBullets()
	{
		_upgraded = false;
	}

	private void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.tag == "Enemy")
			ReceiveDamage();
	}
}
