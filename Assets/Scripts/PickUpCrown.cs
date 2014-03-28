using UnityEngine;
using System.Collections;

public class PickUpCrown : MonoBehaviour {

	public string collidedTo;
	
	void OnCollisionEnter (Collision collision) {
		Debug.Log ("OnCollisionEnter: " + collision.gameObject.tag + " - " + collidedTo);
		if (collision.gameObject.tag == collidedTo)
		{
			Destroy(gameObject);
			Application.LoadLevel("Win_Screen");
		}
	}
}
