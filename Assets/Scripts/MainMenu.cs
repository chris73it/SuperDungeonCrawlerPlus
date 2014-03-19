using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
	
	void OnGUI() {

		GUI.BeginGroup(new Rect(Screen.width / 2 - 75, Screen.height / 2 - 150, 800, 600));

		GUI.color = Color.green;
		if (GUI.Button(new Rect(10, 50, 200, 50), "Play")) {
			Debug.Log("Clicked the Play button");
			Globals.numLives = Globals.INITIAL_LIVES;
			Application.LoadLevel(++Globals.currentLevel); // go to character selection screen (NOTE: main menu is 0)
		}

		//if (GUI.Button(new Rect(10, 170, 200, 50), "Options")) {
		//	Debug.Log("Clicked the Options button");
		//	Application.LoadLevel("Level_0_Options_Menu"); // options screen
		//}

		GUI.color = Color.red;
		if (GUI.Button(new Rect(10, 230, 200, 50), "Exit")) {
			Debug.Log("Clicked the Exit button");
			Application.Quit();
		}

		GUI.EndGroup();
	}
}