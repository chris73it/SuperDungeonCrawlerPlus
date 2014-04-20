using UnityEngine;
using System.Collections;

public class Follow : MonoBehaviour {

	public float speed;

	GameObject target;
//	float distance;
	const float interval = 0.1f;
	
	void Start () {
		target = GameObject.Find("Player");
		StartCoroutine("FollowTarget");
	}
	
	IEnumerator FollowTarget () {
		Vector3 fromToDir;
		for (;;) {
			fromToDir = target.transform.position - transform.position;
//			distance = fromToDir.magnitude;
//			if (distance < Globals.meleeDistance) {
//				if (Input.GetKeyDown(KeyCode.Z)) {
//					Destroy(gameObject);
//				}
//			} else {
				fromToDir.Normalize();
				rigidbody.velocity = fromToDir * speed;
//			}
			yield return new WaitForSeconds(interval); 
		}
	}
}
