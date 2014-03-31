using UnityEngine;
using System.Collections;

public class EnterFromPinkWormHole : MonoBehaviour {
	
	public string collidedTo;
	public GameObject toPinkWormHole;

	void OnCollisionEnter (Collision collision) {
		Debug.Log("OnCollisionEnter: " + collision.gameObject.tag + " - " + collidedTo);
		if (collision.gameObject.tag == collidedTo)
		{
			audio.Play();
			collision.gameObject.transform.position = toPinkWormHole.transform.position;
		}
	}
}