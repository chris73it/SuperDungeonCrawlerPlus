using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {

	public float speed;
	public GameObject bullet;
	public float minDistance;
	public float interval;

	GameObject target;
	Vector3 fromToDir;

	void Start () {
		target = GameObject.Find("Player");
		StartCoroutine("ShootTarget");
	}
	
	IEnumerator ShootTarget () {
		for (;;) {
			if ((target.transform.position - transform.position).magnitude < minDistance) {
				fromToDir = target.transform.position - transform.position;
				fromToDir.Normalize();

				Vector3 newPosition = transform.position;
				newPosition.y += 1.5f;

				GameObject newBullet = Instantiate(bullet, newPosition, Quaternion.identity) as GameObject;
				newBullet.rigidbody.velocity = fromToDir * speed;
			}
			yield return new WaitForSeconds(interval);
		}
	}
}