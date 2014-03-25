using UnityEngine;
using System.Collections;

public class EnterFromRedWormHole : MonoBehaviour {
	
	public string collidedTo;
	public GameObject toRedWormHole;

	void OnCollisionEnter (Collision collision) {
		Debug.Log("OnCollisionEnter: " + collision.gameObject.tag + " - " + collidedTo);
		if (collision.gameObject.tag == collidedTo)
		{
			collision.gameObject.transform.position = toRedWormHole.transform.position;
		}
	}
}