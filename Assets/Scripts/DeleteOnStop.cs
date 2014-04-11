using UnityEngine;
using System.Collections;

public class DeleteOnStop : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		if (rigidbody.velocity.magnitude < 1 || rigidbody.position.y < Globals.MINIMUM_HEIGHT) {
			Destroy(gameObject); 
		}
	}
}
