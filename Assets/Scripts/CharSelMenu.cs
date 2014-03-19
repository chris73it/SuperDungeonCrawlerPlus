using UnityEngine;
using System.Collections;

public class CharSelMenu : MonoBehaviour {

	void OnGUI() {

		bool clicked = false;

		GUI.BeginGroup(new Rect(Screen.width / 2 - 75, Screen.height / 2 - 150, 800, 600));

		GUI.color = Color.red;
		if (GUI.Button(new Rect(10, 110, 200, 50), "Warrior")) {
			Debug.Log("Clicked the Warrior button");
			clicked = true;
			Globals.playerColor = Color.red;
		}

		GUI.color = Color.green;
		if (GUI.Button(new Rect(10, 170, 200, 50), "Archer")) {
			Debug.Log("Clicked the Archer button");
			clicked = true;
			Globals.playerColor = Color.green;
		}

		GUI.color = Color.blue;
		if (GUI.Button(new Rect(10, 230, 200, 50), "Wizard")) {
			Debug.Log("Clicked the Wizard button");
			clicked = true;
			Globals.playerColor = Color.blue;
		}

		GUI.color = Color.yellow;
		if (GUI.Button(new Rect(10, 290, 200, 50), "Knight")) {
			Debug.Log("Clicked the Knight button");
			clicked = true;
			Globals.playerColor = Color.yellow;
		}

		if (clicked == true) {
			Application.LoadLevel(++Globals.currentLevel); // first level
		}

		GUI.EndGroup();
	}
}