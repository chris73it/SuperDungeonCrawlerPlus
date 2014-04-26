using UnityEngine;
using System.Collections;

public class CharSelMenu : MonoBehaviour {
	
	void OnGUI() {

		bool clicked = false;

		GUI.BeginGroup(new Rect(0, 0, Screen.width, Screen.height));

		float distanceBetweenButtons = (Screen.width-4*Globals.MENU_BUTTON_WIDTH)/5;

		GUI.color = Color.red;
		if (GUI.Button(new Rect(distanceBetweenButtons, 550, 200, 50), "Knight")) {
			Debug.Log("Clicked the Warrior button");
			clicked = true;
			Globals.playerColor = GUI.color;
		}

		GUI.color = Color.green;
		if (GUI.Button(new Rect(2*distanceBetweenButtons+Globals.MENU_BUTTON_WIDTH, 550, 200, 50), "Mage")) {
			Debug.Log("Clicked the Archer button");
			clicked = true;
			Globals.playerColor = GUI.color;
		}

		GUI.color = Color.cyan;
		if (GUI.Button(new Rect(3*distanceBetweenButtons+2*Globals.MENU_BUTTON_WIDTH, 550, 200, 50), "Assassin")) {
			Debug.Log("Clicked the Wizard button");
			clicked = true;
			Globals.playerColor = GUI.color;
		}

		GUI.color = Color.magenta;
		if (GUI.Button(new Rect(4*distanceBetweenButtons+3*Globals.MENU_BUTTON_WIDTH, 550, 200, 50), "Amazon")) {
			Debug.Log("Clicked the Knight button");
			clicked = true;
			Globals.playerColor = GUI.color;
		}

		if (clicked == true) {
			Globals.numLives = Globals.INITIAL_LIVES;
			Globals.playerEnergy = Globals.INITIAL_ENERGY;
			Globals.score = 0;
			Globals.currentLevel = 2;
			Application.LoadLevel(++Globals.currentLevel); // first level
		}

		GUI.EndGroup();
	}
}