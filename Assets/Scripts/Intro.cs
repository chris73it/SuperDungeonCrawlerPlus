using UnityEngine;
using System.Collections;

public class Intro : MonoBehaviour {
	
	public Texture logo;
	
	void OnGUI() {
		
		GUI.BeginGroup(new Rect(0, 0, Screen.width, Screen.height));
		
		GUI.Box(new Rect((Screen.width/2-128),10,256,256), logo);
		
		GUI.Box(new Rect(0,300,Screen.width,100), @"Four Heroes are tasked with dispatching the wretched Soul Smith.
He has overthrown Elna, city in the clouds and home of the peaceful Ispi.
Few of these faeries managed to escape the Soul Smith.
Those that remained have been turned into soulless Naughts, hollow beings to do his bidding.

Will you end the tyranny of the Soul Smith? Choose your Hero, and may Heaven Fall…");
		
		GUI.color = Color.green;
		if (GUI.Button(new Rect((Screen.width-Globals.MENU_BUTTON_WIDTH)/2, 450, Globals.MENU_BUTTON_WIDTH, Globals.MENU_BUTTON_HEIGHT), "Play")) {
			Debug.Log("Clicked the Play button");
			Globals.currentLevel = 2; // skip the main menu
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