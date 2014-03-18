using UnityEngine;
using System.Collections;

public class Shortcuts : MonoBehaviour {

	static public int weaponType = 3;

	// Update is called once per frame
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
			weaponType = 1;
		} else if (Input.GetKeyDown("2")) {
			weaponType = 2;
		} if (Input.GetKeyDown("3")) {
			weaponType = 3; 
		}
	}
}
