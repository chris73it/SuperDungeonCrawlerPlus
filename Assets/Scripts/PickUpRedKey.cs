using UnityEngine;
using System.Collections;

public class PickUpRedKey : MonoBehaviour {

	static public bool gotRedKey = false;

	public string collidedTo;

	void OnCollisionEnter (Collision collision) {
		Debug.Log ("OnCollisionEnter: " + collision.gameObject.tag + " - " + collidedTo);
		if (collision.gameObject.tag == collidedTo)
		{
			gotRedKey = true;
			Destroy(gameObject); 
		}
	}
}
