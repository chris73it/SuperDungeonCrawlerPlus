using UnityEngine;
using System.Collections;

public class CollisionDetection : MonoBehaviour {

	public string collidedTo;

	void OnCollisionEnter (Collision collision)
	{
		if (collision.gameObject.tag == collidedTo)
		{
			Destroy(gameObject);
			Destroy (collision.gameObject);
		}
	}
}
