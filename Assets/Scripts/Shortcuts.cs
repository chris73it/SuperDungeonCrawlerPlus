using UnityEngine;
using System.Collections;

public class Shortcuts : MonoBehaviour {

	void Update () {
		// Pause/Unpause the game by pressing P
		if (Input.GetKeyDown(KeyCode.P)) {
			if ( Time.timeScale > 0.0f) {
				Time.timeScale = 0.0f;
			} else {
				Time.timeScale = 1.0f;
			}
			Time.fixedDeltaTime = 0.02F * Time.timeScale;
		}

		// Select weapon type (debug only)
		if (Input.GetKeyDown("1")) {
			Globals.weaponType = 1;
		} else if (Input.GetKeyDown("2")) {
			Globals.weaponType = 2;
		} if (Input.GetKeyDown("3")) {
			Globals.weaponType = 3; 
		}
	}
}
