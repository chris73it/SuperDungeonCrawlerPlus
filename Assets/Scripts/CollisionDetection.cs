using UnityEngine;
using System.Collections;

public class CollisionDetection : MonoBehaviour {

	public string collidedTo;

	void OnCollisionEnter (Collision collision)
	{
		if (collision.gameObject.tag == collidedTo)
		{
			Destroy (collision.gameObject);
			audio.Play();
			StartCoroutine("DeferredSuicide", gameObject);
		}
	}
	
	IEnumerator DeferredSuicide(GameObject enemy) {
		enemy.transform.Translate(new Vector3(0,-10,0));
		yield return new WaitForSeconds(2f);
		Destroy(enemy);
	}
}
