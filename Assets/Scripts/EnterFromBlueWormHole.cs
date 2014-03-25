using UnityEngine;
using System.Collections;

public class EnterFromBlueWormHole : MonoBehaviour {
	
	public string collidedTo;
	public GameObject toBlueWormHole;

	void OnCollisionEnter (Collision collision) {
		Debug.Log("OnCollisionEnter: " + collision.gameObject.tag + " - " + collidedTo);
		if (collision.gameObject.tag == collidedTo)
		{
			collision.gameObject.transform.position = toBlueWormHole.transform.position;
		}
	}
}