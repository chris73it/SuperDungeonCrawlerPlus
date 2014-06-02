using UnityEngine;
using System.Collections;

public class PickUpCrown : MonoBehaviour {
	
	public string collidedTo;
	
	void OnCollisionEnter (Collision collision)
	{
		if (collision.gameObject.tag == collidedTo)
		{
			audio.Play();
			StartCoroutine("DeferredSuicide", gameObject);
			Globals.score += 100;
		}
	}
	
	IEnumerator DeferredSuicide(GameObject crown) {
		crown.transform.Translate(new Vector3(0,-10,0));
		yield return new WaitForSeconds(2f);
		Destroy(crown);
	}
}