using UnityEngine;
using System.Collections;

public class PickUpPotion : MonoBehaviour {

	public string collidedTo;
	
	void OnCollisionEnter (Collision collision) {
		Debug.Log ("OnCollisionEnter: " + collision.gameObject.tag + " - " + collidedTo);
		if (collision.gameObject.tag == collidedTo)
		{
			Destroy (gameObject);
			Globals.playerEnergy += 30f;
			if (Globals.playerEnergy > 100f) {
				Globals.playerEnergy = 100f;
			}
		}
	}
}
