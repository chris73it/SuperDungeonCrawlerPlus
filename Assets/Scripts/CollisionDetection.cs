using UnityEngine;
using System.Collections;

public class CollisionDetection : MonoBehaviour {

	public string collidedTo;

	int enemyEnergy = Globals.ENEMY_INITIAL_ENERGY;

	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == collidedTo) {
			Destroy(collision.gameObject); // remove bullet
			--enemyEnergy;
		} else if (Globals.destroyWhileFastForwarding == true) {
			enemyEnergy = 0;
		}

		if (enemyEnergy <= 0) {
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
