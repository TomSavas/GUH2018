using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class BulletBehavior : MonoBehaviour {
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
			other.gameObject.GetComponent<PlayerBehavior>().ReceiveDamage();
			Destroy(gameObject);
		}
		else if (other.tag == "Border")
		{
			Physics2D.IgnoreCollision(GetComponent<CircleCollider2D>(), other);
			Destroy(gameObject, 0.5f);
		}
	}
}
