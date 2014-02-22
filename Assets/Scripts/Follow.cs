using UnityEngine;
using System.Collections;

public class Follow : MonoBehaviour {

	public float speed;

	private GameObject target;
	private float interval = 0.1f;
	
	void Start () {
		target = GameObject.Find("Player");
		StartCoroutine("FollowTarget");
	}
	
	IEnumerator FollowTarget () {
		for (;;) {
			Vector3 fromToDir = target.transform.position - transform.position;
			fromToDir.Normalize();
			rigidbody.velocity = fromToDir * speed;
			yield return new WaitForSeconds(interval);
		}
	}
}
