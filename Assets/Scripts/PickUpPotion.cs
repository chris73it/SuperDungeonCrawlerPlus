﻿using UnityEngine;
using System.Collections;

public class PickUpBigPotion : MonoBehaviour {

	public string collidedTo;
	
	void OnCollisionEnter (Collision collision) {
		Debug.Log ("OnCollisionEnter: " + collision.gameObject.tag + " - " + collidedTo);
		if (collision.gameObject.tag == collidedTo)
		{
			audio.Play();
			StartCoroutine("DeferredSuicide", gameObject);
			Globals.score += 50;
			Globals.playerEnergy = Globals.INITIAL_ENERGY;
			if (Globals.playerEnergy > 100f) {
				Globals.playerEnergy = 100f;
			}
		}
	}

	IEnumerator DeferredSuicide(GameObject potion) {
		potion.transform.Translate(new Vector3(0,-10,0));
		yield return new WaitForSeconds(2f);
		Destroy(potion);
	}
}