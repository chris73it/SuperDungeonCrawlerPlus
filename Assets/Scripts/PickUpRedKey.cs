using UnityEngine;
using System.Collections;

public class PickUpRedKey : MonoBehaviour {

	static public bool gotRedKey = false;

	public string collidedTo;

	void OnCollisionEnter (Collision collision) {
		Debug.Log ("OnCollisionEnter: " + collision.gameObject.tag + " - " + collidedTo);
		if (collision.gameObject.tag == collidedTo)
		{
			audio.Play();
			gotRedKey = true;
			StartCoroutine("DeferredSuicide", gameObject);
		}
	}
	
	IEnumerator DeferredSuicide(GameObject key) {
		key.transform.Translate(new Vector3(0,-10,0));
		yield return new WaitForSeconds(2f);
		Destroy(key);
	}
}
