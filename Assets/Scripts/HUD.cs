using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour {
	// drag a texture as the icon to move on the progress bar
	public Texture vertBar;
	
	// GUI bar width height and progress
	const float labelWidth = 48f;
	const float barWidth = 128f;
	const float barHeight = 24f;

	float maxEnergy = Globals.MAX_ENERGY + 1f; // the +1f makes player's energy still visible when it is max out
	float maxFire = Globals.MAX_FIRE + 1f; // the +1f makes fire level still visible when it is max out

	float barWidthOverMaxEnergy;
	float barWidthOverMaxFire;
	void Start() {
		barWidthOverMaxEnergy = barWidth / maxEnergy;
		barWidthOverMaxFire = barWidth / maxFire;
	}

	float barEnergyProgress;
	float barFireProgress;
	void Update() {
		//turn the playerDist into the scale of barWidth
		barEnergyProgress = Globals.playerEnergy * barWidthOverMaxEnergy;
		barFireProgress = Globals.fireHoldTime * barWidthOverMaxFire;
	}
	
	void OnGUI() {
		// create a GUI group the width of the bar and twice its height
		// in order to leave room for 'Start' and 'End' text under the bar
		GUI.BeginGroup(new Rect (10, 10, 2*labelWidth+barWidth, 5*barHeight));
		
		// add level text label at the very top position within the GUI.group
		if (Globals.currentLevel >= Globals.LAST_LEVEL) {
			GUI.Label(new Rect(0, 0, 2*labelWidth, barHeight), "Level   " + (Globals.LAST_LEVEL-2));
		} else if (Globals.currentLevel >= 0) {
			GUI.Label(new Rect(0, 0, 2*labelWidth, barHeight), "Level   " + (Globals.currentLevel-2));
		}
		
		// add lives text label at the middle position within the GUI.group
		GUI.Label(new Rect(0, barHeight, 2*labelWidth, barHeight), "Lives   "+Globals.numLives.ToString());
		
		// add energy text label at the leftmost position within the GUI.group
		GUI.Label(new Rect(0, 2*barHeight, labelWidth, barHeight), "Energy");
		//draw a box as the backing for the progress bar, blank text inside
		GUI.Box(new Rect(labelWidth, 2*barHeight, barWidth, barHeight), "");
		// add energy texture label that works as an indicator of the remaining energy
		GUI.Label(new Rect(labelWidth+barEnergyProgress, 2*barHeight, vertBar.width, barHeight), vertBar);
		
		// add score text label at the bottom position within the GUI.group
		GUI.Label(new Rect(0, 3*barHeight, 2*labelWidth, barHeight), "Score  "+Globals.score.ToString()); 
		
		// add fire text label at the leftmost position within the GUI.group
		GUI.Label(new Rect(0, 4*barHeight, labelWidth, barHeight), "Fire");
		//draw a box as the backing for the progress bar, blank text inside
		GUI.Box(new Rect(labelWidth, 4*barHeight, barWidth, barHeight), "");
		// add energy texture label that works as an indicator of the remaining energy
		GUI.Label(new Rect(labelWidth+barFireProgress, 4*barHeight, vertBar.width, barHeight), vertBar);

		GUI.EndGroup();
	}
}