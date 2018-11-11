using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
	public int Health;
	public float InvulnerabilityTime;
	public float BlinkHoldback;

	private bool _invulnerable;
	private float _invulnerabilityTime;
	private SpriteRenderer _spriteRenderer;

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
	}
	
	public void ReceiveDamage()
	{
		if (!_invulnerable)
		{
			Health -= 1;
			_invulnerable = true;
			_invulnerabilityTime = InvulnerabilityTime;
		}
	}

	private float _blinkHoldback;
	private bool _transparent;
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
	}

	public void IncrementHealth()
	{
		if (Health < 3)
			Health += 1;
	}

	private void Shoot()
	{
		
	}

	public void UpgradeBullets()
	{
		
	}

	public void DowngradeBullets()
	{
		
	}
}
