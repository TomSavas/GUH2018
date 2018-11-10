using UnityEngine;

public abstract class BasicTouchpoint : MonoBehaviour
{
	public float Lifetime;
	public float MaxRange;
	public float MinRange;

	private void Update ()
	{
		if (Lifetime > 0f)
		{
			foreach(GameObject player in GameObject.FindGameObjectsWithTag("Player"))
			{
				Vector2 touchpointToPlayer = new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y);
				ActOnPlayer(player, touchpointToPlayer);
			}

			/* TODO: define Enemy tag
			foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
			{
				Vector2 touchpointToEnemy = new Vector2(enemy.transform.position.x - transform.position.x, enemy.transform.position.y - transform.position.y);
				ActOnEnemy(enemy, touchpointToEnemy);
			}
			*/
			

			Lifetime = CalculateLifetime(Lifetime);
		}
		else
		{
			Destroy(gameObject);
		}
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.black;
		Gizmos.DrawWireSphere(transform.position, MinRange);
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, MaxRange);
	}

	public virtual float CalculateLifetime(float lifetime)
	{
		return lifetime - Time.deltaTime;
	}

	public abstract void ActOnPlayer(GameObject player, Vector2 touchpointToPlayer);
	public abstract void ActOnEnemy(GameObject enemy, Vector2 touchpointToEnemy);
}
