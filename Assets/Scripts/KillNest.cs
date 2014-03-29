using UnityEngine;
using System.Collections;

public class KillNest : MonoBehaviour {

	public string collidedTo;

	int nestEnergy = Globals.NEST_INITIAL_ENERGY;
	
	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == collidedTo)
		{
			Destroy(collision.gameObject);
			if (--nestEnergy <= 0) {
				audio.Play();
				StartCoroutine("DeferredSuicide", gameObject);
				Globals.score += 100;
			}
		}
	}
	
	IEnumerator DeferredSuicide(GameObject enemy) {
		enemy.transform.Translate(new Vector3(0,-20,0));
		yield return new WaitForSeconds(2f); // FIXME: why if we wait 2f the last enemy reappear?
		Destroy(enemy);
	}
}