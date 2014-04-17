using UnityEngine;
using System.Collections;

public class DeleteOnStop : MonoBehaviour {

	public float minVelocity;

	// Update is called once per frame
	void Update () {
		if (rigidbody.velocity.magnitude < minVelocity || rigidbody.position.y < Globals.MINIMUM_HEIGHT) {
			Destroy(gameObject); 
		}
	}
}
