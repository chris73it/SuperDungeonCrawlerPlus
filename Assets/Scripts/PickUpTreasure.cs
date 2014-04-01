using UnityEngine;
using System.Collections;

public class PickUpTreasure : MonoBehaviour {

	public string collidedTo;
	
	void OnCollisionEnter (Collision collision)
	{
		if (collision.gameObject.tag == collidedTo)
		{
			audio.Play();
			StartCoroutine("DeferredSuicide", gameObject);
			Globals.score += 70;
		}
	}
	
	IEnumerator DeferredSuicide(GameObject treasure) {
		treasure.transform.Translate(new Vector3(0,-10,0));
		yield return new WaitForSeconds(2f);
		Destroy(treasure);
	}
}