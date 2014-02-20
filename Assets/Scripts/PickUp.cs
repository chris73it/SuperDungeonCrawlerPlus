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
//			Vector3 newPosition = transform.position;
//			newPosition.y = -10.0f; //FIXME: the inventory is under the floor
//									// check the y cohordinate to know whether it
//									// has been picked up.
//			transform.position = newPosition;
		}
	}
}
