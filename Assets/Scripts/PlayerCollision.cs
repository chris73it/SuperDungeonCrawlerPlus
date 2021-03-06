﻿using UnityEngine;
using System.Collections;

public class PlayerCollision : MonoBehaviour {

	public string collidedTo;
	public AudioClip deathSound;

	void OnCollisionEnter (Collision collision)
	{
		if (collision.gameObject.tag == collidedTo)
		{
			//TODO: push the enemy in the opposite direction of the enemy's motion

			if (Globals.playerEnergy > 0f && Globals.destroyWhileFastForwarding == false) {
				Globals.playerEnergy -= 10f;
				if (Globals.playerEnergy <= 0f) {
					Globals.playerEnergy = 0f;
					--Globals.numLives;
				}
				if (Globals.playerEnergy == 0f) {
					audio.PlayOneShot(deathSound, 1f);
					StartCoroutine("FlyToHeavenWhileFading");
				}
			}
		}
	}
	
	IEnumerator FlyToHeavenWhileFading () {
		Vector3 newPosition = transform.position;
		Color c = renderer.material.color;
		float a, y;

		for (a = 80.0f, y = 5.0f; y < 500.0f; y+=5.0f) {

			c.a = a/100.0f;
			renderer.material.color = c;
			if (a > 0.01f) { a--; } else { a = 0.0f; }

			newPosition.y += y/500.0f;
			transform.position = newPosition;

			yield return new WaitForSeconds(0.016f);
		}
		Debug.Log ("Globals.numLives: " + Globals.numLives);
		if (Globals.numLives == 0) {
			Application.LoadLevel("Fail_Screen");
		} else {
			PickUpBlueKey.gotBlueKey = false; // FIXME
			PickUpRedKey.gotRedKey = false; // FIXME
			PickUpGreenKey.gotGreenKey = false; // FIXME
			PickUpPinkKey.gotPinkKey = false; // FIXME
			Globals.playerEnergy = Globals.INITIAL_ENERGY;
			Application.LoadLevel(Globals.currentLevel);
		}
	}
}