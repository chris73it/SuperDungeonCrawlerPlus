using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour {
	// drag a texture as the icon to move on the progress bar
	public Texture progIcon;
	
	// GUI bar width height and progress
	float barWidth = 128f;
	float barHeight = 24f;
	float barProgress;

	// label
	float energyLabelWidth = 48f;
	
	// energy
	float maxEnergy = 100f + 1f; // the +1f makes playerEnergy still visible when it is 100f
	float barWidthOverMaxEnergy;

	void Start() {
		barWidthOverMaxEnergy = barWidth / maxEnergy;
	}

	void Update() {
		//turn the playerDist into the scale of barWidth
		barProgress = Globals.playerEnergy * barWidthOverMaxEnergy;
	}
	
	void OnGUI() {
		// create a GUI group the width of the bar and twice its height
		// in order to leave room for 'Start' and 'End' text under the bar
		GUI.BeginGroup(new Rect (10, 10, 2*energyLabelWidth+barWidth, 3*barHeight));
		
		// add energy text label at the leftmost position within the GUI.group
		GUI.Label(new Rect(0, 0, energyLabelWidth, barHeight), "Energy");
		
		//draw a box as the backing for the progress bar, blank text inside
		GUI.Box(new Rect(energyLabelWidth, 0, barWidth, barHeight), "");
		
		// add energy texture label that works as an indicator of the remaining energy
		GUI.Label(new Rect(energyLabelWidth+barProgress, 0, progIcon.width, barHeight), progIcon);
		
		// add score text label at the intermediate position within the GUI.group
		//GUI.Label(new Rect(energyLabelWidth+barWidth, barHeight, energyLabelWidth, barHeight), " Lives "+Globals.numLives.ToString());
		GUI.Label(new Rect(0, barHeight, 2*energyLabelWidth, barHeight), "Score  "+Globals.score.ToString());

		// add energy text label at the lowest position within the GUI.group
		//GUI.Label(new Rect(energyLabelWidth+barWidth, barHeight, energyLabelWidth, barHeight), " Lives "+Globals.numLives.ToString());
		GUI.Label(new Rect(0, 2*barHeight, 2*energyLabelWidth, barHeight), "Lives   "+Globals.numLives.ToString());

		GUI.EndGroup();
	}
}