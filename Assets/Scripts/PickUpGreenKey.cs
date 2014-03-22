using UnityEngine;
using System.Collections;

public class PickUpGreenKey : MonoBehaviour {

	static public bool gotGreenKey = false;

	public string collidedTo;

	void OnCollisionEnter (Collision collision) {
		Debug.Log ("OnCollisionEnter: " + collision.gameObject.tag + " - " + collidedTo);
		if (collision.gameObject.tag == collidedTo)
		{
			gotGreenKey = true;
			Destroy(gameObject); 
		}
	}
}
