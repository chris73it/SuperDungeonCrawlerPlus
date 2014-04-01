using UnityEngine;
using System.Collections;

public class PickUpPinkKey : MonoBehaviour {

	static public bool gotPinkKey = false;

	public string collidedTo;

	GameObject centralPillar1;
	GameObject centralPillar2;
	GameObject centralPillar3;

	void Start() {
		centralPillar1 = GameObject.Find("CentralPillar1");
		centralPillar2 = GameObject.Find("CentralPillar2");
		centralPillar3 = GameObject.Find("CentralPillar3");
	}

	void OnCollisionEnter (Collision collision) {
		Debug.Log ("OnCollisionEnter: " + collision.gameObject.tag + " - " + collidedTo);
		if (collision.gameObject.tag == collidedTo)
		{
			audio.Play();
			gotPinkKey = true;
			Destroy(centralPillar1);
			centralPillar2.collider.enabled = true;
			centralPillar2.renderer.enabled = true;
			centralPillar3.collider.enabled = true;
			centralPillar3.renderer.enabled = true;
			StartCoroutine("DeferredSuicide", gameObject);
		}
	}
	
	IEnumerator DeferredSuicide(GameObject key) {
		key.transform.Translate(new Vector3(0,-10,0));
		yield return new WaitForSeconds(2f);
		Destroy(key);
	}
}
