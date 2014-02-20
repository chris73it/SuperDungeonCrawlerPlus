using UnityEngine;
using System.Collections;

public class NextLevel : MonoBehaviour {
	
	public string collidedTo;

	private bool upping = false;
	
	void OnCollisionEnter (Collision collision) {
		Debug.Log ("OnCollisionEnter: " + collision.gameObject.tag + " - " + collidedTo);

		if (PickUp.gotKey == false) { return;  }

		if (collision.gameObject.tag == collidedTo && upping == false)
		{
			upping = true;
			StartCoroutine("GoToNextLevel", collision.gameObject);
		}
	}

	IEnumerator GoToNextLevel (GameObject otherObject) {
		Vector3 newPosition = transform.position;

		yield return new WaitForSeconds(1.5f);

		for (float y = 5.0f; y < 500.0f; y+=5.0f) {

			newPosition.y += y/500.0f;
			transform.position = newPosition;
			otherObject.transform.position = newPosition;

			yield return new WaitForSeconds(0.016f);
		}

		Destroy (gameObject);// Remove the exit/elevator
		Application.LoadLevel(++Globals.currentLevel);
	}
}
