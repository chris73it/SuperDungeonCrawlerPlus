using UnityEngine;
using System.Collections;

public class PickUp : MonoBehaviour {

	static public bool gotKey = false;

	public string collidedTo;

	void OnCollisionEnter (Collision collision) {
		Debug.Log ("OnCollisionEnter: " + collision.gameObject.tag + " - " + collidedTo);
		if (collision.gameObject.tag == collidedTo)
		{
			gotKey = true;
			Destroy (gameObject);
		}
	}
}
