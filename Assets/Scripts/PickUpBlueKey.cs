using UnityEngine;
using System.Collections;

public class PickUpBlueKey : MonoBehaviour {

	static public bool gotBlueKey = false;

	public string collidedTo;

	void OnCollisionEnter (Collision collision) {
		Debug.Log ("OnCollisionEnter: " + collision.gameObject.tag + " - " + collidedTo);
		if (collision.gameObject.tag == collidedTo)
		{
			gotBlueKey = true;
			Destroy (gameObject); 
		}
	}
}
