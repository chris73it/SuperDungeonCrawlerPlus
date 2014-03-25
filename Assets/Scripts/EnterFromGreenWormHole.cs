using UnityEngine;
using System.Collections;

public class EnterFromGreenWormHole : MonoBehaviour {
	
	public string collidedTo;
	public GameObject toGreenWormHole;

	void OnCollisionEnter (Collision collision) {
		Debug.Log("OnCollisionEnter: " + collision.gameObject.tag + " - " + collidedTo);
		if (collision.gameObject.tag == collidedTo)
		{
			collision.gameObject.transform.position = toGreenWormHole.transform.position;
		}
	}
}