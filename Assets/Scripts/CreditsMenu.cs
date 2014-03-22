using UnityEngine;
using System.Collections;

public class CreditsMenu : MonoBehaviour {

	bool clickedBri = false;
	bool clickedRoss = false;
	bool clickedChris = false;

	void OnGUI() {

		GUI.BeginGroup(new Rect(0, 0, Screen.width, Screen.height));

		float distanceBetweenButtons = (Screen.width-3*Globals.MENU_BUTTON_WIDTH)/4;

		GUI.color = Color.magenta;
		if (GUI.Button(new Rect(distanceBetweenButtons, 350, Globals.MENU_BUTTON_WIDTH, Globals.MENU_BUTTON_HEIGHT), "Brianna Grizzell")) {
			clickedBri = true;
			clickedRoss = false;
			clickedChris = false;
		}

		GUI.color = Color.yellow;
		if (GUI.Button(new Rect(2*distanceBetweenButtons+Globals.MENU_BUTTON_WIDTH, 350, Globals.MENU_BUTTON_WIDTH, Globals.MENU_BUTTON_HEIGHT), "Ross Breedlove")) {
			clickedBri = false;
			clickedRoss = true;
			clickedChris = false;
		}

		GUI.color = Color.cyan;
		if (GUI.Button(new Rect(3*distanceBetweenButtons+2*Globals.MENU_BUTTON_WIDTH, 350, Globals.MENU_BUTTON_WIDTH, Globals.MENU_BUTTON_HEIGHT), "Christian Sasso")) {
			clickedBri = false;
			clickedRoss = false;
			clickedChris = true;
		}

		GUI.color = Color.green;
		if (GUI.Button(new Rect((Screen.width-Globals.MENU_BUTTON_WIDTH)/2, 650, Globals.MENU_BUTTON_WIDTH, Globals.MENU_BUTTON_HEIGHT), "Play")) {
			Debug.Log("Clicked the Play button");
			Globals.currentLevel = 2;
			Application.LoadLevel(Globals.currentLevel); // go to character selection screen
		}

		if (clickedBri == true) {
			GUI.color = Color.magenta;
			GUI.TextField(new Rect(distanceBetweenButtons, 150, Globals.MENU_BUTTON_WIDTH, Globals.MENU_BUTTON_HEIGHT), "Bri's section");
		} else if (clickedRoss == true) {
			GUI.color = Color.yellow;
			GUI.TextField(new Rect(2*distanceBetweenButtons+Globals.MENU_BUTTON_WIDTH, 150, Globals.MENU_BUTTON_WIDTH, Globals.MENU_BUTTON_HEIGHT), "Ross's section");
		} else if (clickedChris == true) {
			GUI.color = Color.cyan;
			GUI.TextField(new Rect(3*distanceBetweenButtons+2*Globals.MENU_BUTTON_WIDTH, 150, Globals.MENU_BUTTON_WIDTH, Globals.MENU_BUTTON_HEIGHT), "Code design and implementation");
		}

		GUI.EndGroup();
	}
}