using UnityEngine;
using System.Collections;

public class DeleteOnStop : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		if (rigidbody.velocity == Vector3.zero) {
			Destroy(gameObject); 
		}
	}
}
