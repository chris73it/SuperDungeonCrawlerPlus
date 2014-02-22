using UnityEngine;
using System.Collections;

public class NextLevel : MonoBehaviour {
	
	public string collidedTo;

	private float speed = 4.0f;
	private GameObject target;
	private float interval = 0.01f;
	private bool upping = false;
	private Collision collision;

	void OnCollisionExit (Collision collision) {
		Debug.Log ("OnCollisionExit");

		upping = false;
		Debug.Log("No longer in contact with " + collision.transform.name);
	}

	void OnCollisionEnter (Collision collision) {
		Debug.Log ("OnCollisionEnter: " + collision.gameObject.tag);

		if (PickUp.gotKey == false) { return;  }

		if (collision.gameObject.tag == collidedTo && upping == false)
		{
			upping = true;
			target = GameObject.Find("Player");
			StartCoroutine("CenterTarget", collision);
		}
	}

	IEnumerator CenterTarget (Collision collision) {
		for (;;) {
			if (upping == false) {
				yield break;
			}
			Vector3 fromToDir = transform.position - target.transform.position;
			Debug.Log ("CenterTarget: " + fromToDir.magnitude);
			if (fromToDir.magnitude < 0.54f) {
				if (upping == true) {
					Vector3 newPosition = transform.position;
					target.transform.position = newPosition;
					for (float y = 5.0f; y < 500.0f; y+=5.0f) {
						newPosition.y += y/500.0f;
						transform.position = newPosition;
						collision.gameObject.transform.position = newPosition;
						yield return new WaitForSeconds(0.016f);
					}
					Destroy (gameObject);// Remove the exit/elevator
					Application.LoadLevel(++Globals.currentLevel);
				}
				yield break;
			} //else {
				fromToDir.Normalize();
				rigidbody.velocity = fromToDir * speed;
				yield return new WaitForSeconds(interval);
			//}
		}
	}

	/*	
	IEnumerator GoToNextLevel (GameObject otherObject) {
		Debug.Log ("GoToNextLevel");
		Vector3 newPosition = transform.position;

		for (float y = 5.0f; y < 500.0f; y+=5.0f) {

			newPosition.y += y/500.0f;
			transform.position = newPosition;
			otherObject.transform.position = newPosition;

			yield return new WaitForSeconds(0.016f);
		}
		Destroy (gameObject);// Remove the exit/elevator
		Application.LoadLevel(++Globals.currentLevel);
	}
	*/
}
