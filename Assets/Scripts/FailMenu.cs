using UnityEngine;
using System.Collections;

public class FailMenu : MonoBehaviour {
	
	void OnGUI() {
		
		GUI.BeginGroup(new Rect(0, 0, Screen.width, Screen.height));

		GUI.color = Color.green;
		if (GUI.Button(new Rect((Screen.width-Globals.MENU_BUTTON_WIDTH)/2, 450, Globals.MENU_BUTTON_WIDTH, Globals.MENU_BUTTON_HEIGHT), "Play")) {
			Debug.Log("Clicked the Play button");
			Globals.currentLevel = 2; // when in the fail screen, the level is much greater than 1, so it needs "resetting"
			Application.LoadLevel(Globals.currentLevel); // go to character selection screen
		}
		
		GUI.color = Color.yellow;
		if (GUI.Button(new Rect((Screen.width-Globals.MENU_BUTTON_WIDTH)/2, 550, Globals.MENU_BUTTON_WIDTH, Globals.MENU_BUTTON_HEIGHT), "Credits")) {
			Debug.Log("Clicked the Credits button");
			Application.LoadLevel("Credits_Screen"); // credits screen
		}
		
		GUI.color = Color.red;
		if (GUI.Button(new Rect((Screen.width-Globals.MENU_BUTTON_WIDTH)/2, 650, Globals.MENU_BUTTON_WIDTH, Globals.MENU_BUTTON_HEIGHT), "Exit")) {
			Debug.Log("Clicked the Exit button");
			Application.Quit();
		}
		
		GUI.EndGroup();
	}
}