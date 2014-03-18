using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

	public Texture btnTexture;

	void OnGUI() {

		GUI.BeginGroup(new Rect(Screen.width / 2, Screen.height / 2 - 150, 800, 600));

		if (GUI.Button(new Rect(10, 10, 50, 50), "Play")) {
			Debug.Log("Clicked the Play button");
			Globals.currentLevel = 1;
			Application.LoadLevel(Globals.currentLevel); // first level
		}

		if (GUI.Button(new Rect(10, 70, 50, 50), "Options")) {
			Debug.Log("Clicked the Options button");

		}

		if (GUI.Button(new Rect(10, 130, 50, 50), "Exit")) {
			Debug.Log("Clicked the Exit button");
			Application.Quit();
		}

		GUI.EndGroup();
	}
}