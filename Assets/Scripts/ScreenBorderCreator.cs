using UnityEngine;

public class ScreenBorderCreator: MonoBehaviour
{
	private void Awake() 
	{
		SetBoundaries();
	}

	private void SetBoundaries()
	{
		ApplyColliderToGameObject(CreateWallObject("Top_Border"),
			Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0.0f)),
			Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 0.0f))
		);
		ApplyColliderToGameObject(CreateWallObject("Bottom_Border"),
			Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0.0f)),
			Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0.0f))
		);
		ApplyColliderToGameObject(CreateWallObject("Left_Border"),
			Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0.0f)),
			Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0.0f))
		);
		ApplyColliderToGameObject(CreateWallObject("Right_Border"),
			Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0.0f)),
			Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 0.0f))
		);
	}

	private GameObject CreateWallObject(string name)
	{
		var gameObject = new GameObject(name);
		gameObject.tag = "Border";
		gameObject.transform.parent = transform;
		var rigidBody = gameObject.AddComponent<Rigidbody2D> ();
		rigidBody.gravityScale = 0;
		rigidBody.constraints = RigidbodyConstraints2D.FreezeAll;
		return gameObject;
	}

	private void ApplyColliderToGameObject(GameObject gameObject, Vector3 startOfBoundary, Vector3 endOfBoundary)
	{
		var collider = gameObject.AddComponent<BoxCollider2D>();
		collider.offset = ToVector2((startOfBoundary + endOfBoundary) / 2);
		collider.size = Vector2.one;
		if (Mathf.Abs(collider.offset.x) > 0)
		{
			collider.size += new Vector2(1f, ToVector2(Abs(startOfBoundary) + Abs(endOfBoundary)).y);
			collider.offset += new Vector2(collider.size.x / 2 * Mathf.Sign(collider.offset.x), 0f);
		}
		else if (Mathf.Abs(collider.offset.y) > 0)
		{
			collider.size += new Vector2(ToVector2(Abs(startOfBoundary) + Abs(endOfBoundary)).x, 1f);
			collider.offset += new Vector2(0f, collider.size.y / 2 * Mathf.Sign(collider.offset.y));
		}
	}

	private Vector2 ToVector2(Vector3 vector3)
	{
		return new Vector2(vector3.x, vector3.y);
	}

	private Vector2 Abs(Vector2 vector2)
	{
		return new Vector2(Mathf.Abs(vector2.x), Mathf.Abs(vector2.y));
	}
}
