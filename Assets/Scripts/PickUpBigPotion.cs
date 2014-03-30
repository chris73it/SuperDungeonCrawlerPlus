using UnityEngine;
using System.Collections;

public class PickUpPotion : MonoBehaviour {

	public string collidedTo;
	
	void OnCollisionEnter (Collision collision) {
		Debug.Log ("OnCollisionEnter: " + collision.gameObject.tag + " - " + collidedTo);
		if (collision.gameObject.tag == collidedTo)
		{
			audio.Play();
			StartCoroutine("DeferredSuicide", gameObject);
			Globals.score += 200;
			Globals.playerEnergy += Globals.INITIAL_ENERGY *3 /10;
			if (Globals.playerEnergy > Globals.INITIAL_ENERGY) {
				Globals.playerEnergy = Globals.INITIAL_ENERGY;
			}
		}
	}

	IEnumerator DeferredSuicide(GameObject potion) {
		potion.transform.Translate(new Vector3(0,-10,0));
		yield return new WaitForSeconds(2f);
		Destroy(potion);
	}
}