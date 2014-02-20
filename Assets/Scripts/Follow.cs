using UnityEngine;
using System.Collections;

public class Follow : MonoBehaviour {

	public float speed;

	private Move move;
	private GameObject target;
	private float interval = 0.1f;

	// Use this for initialization
	void Start () {
		move = GameObject.Find("Player").GetComponent("Move") as Move;
		target = move.gameObject;
		StartCoroutine("FollowTarget");
	}
	
	// FIXME: make a coroutine
	IEnumerator FollowTarget () {
		for (;;) {
			Vector3 fromToDir = target.transform.position - transform.position;
			fromToDir.Normalize();
			rigidbody.velocity = fromToDir * speed;
			yield return new WaitForSeconds(interval);
		}
	}
}
