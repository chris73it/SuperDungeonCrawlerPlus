using UnityEngine;
using System.Collections;

public class NextGreenLevel : MonoBehaviour {

	GameObject target;
	float speed = 2.5f;

	void Start() {
		target = GameObject.Find("Player");
	}

	void OnCollisionEnter (Collision collision) {

		if (PickUpGreenKey.gotGreenKey == false) { return;  }

		if (collision.gameObject == target)
		{
			StartCoroutine("CenterTarget", collision);
		}
	}

	IEnumerator CenterTarget (Collision collision) {
		Vector3 newPosition;
		Vector3 fromToDir;
		for (float y = 5.0f; y < 500.0f; y+=5.0f) {
			newPosition = collision.gameObject.transform.position;
			newPosition.y += y/500.0f;
			collision.gameObject.transform.position = newPosition;

			newPosition = transform.position;
			newPosition.y = collision.gameObject.transform.position.y;
			fromToDir = newPosition - collision.gameObject.transform.position;
			fromToDir.Normalize();
			collision.rigidbody.velocity = fromToDir * speed;
			yield return new WaitForSeconds(0.016f);
		}
		PickUpGreenKey.gotGreenKey = false;
		Globals.currentLevel += 2;
		Application.LoadLevel(Globals.currentLevel); 
	}
}