using UnityEngine;
using System.Collections;

public class Energy : MonoBehaviour {
	// drag a texture as the icon to move on the progress bar
	public Texture progIcon;
	
	// GUI bar width height and progress
	float barWidth = 128f;
	float barHeight = 24f;
	float barProgress;

	// label
	float labelWidth = 48f;
	
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
		GUI.BeginGroup(new Rect (10, 10, labelWidth+barWidth, barHeight));
		
		// add energy text label at the leftmost position within the GUI.group
		GUI.Label(new Rect(0, 0, labelWidth, barHeight), "Energy");
		
		//draw a box as the backing for the progress bar, blank text inside
		GUI.Box(new Rect(labelWidth, 0, barWidth, barHeight), "");
		
		// create a label to draw the progress icon texture, use barProgress var
		// to set its X position, 0 as the Y position and width and height of the texture used
		GUI.Label(new Rect(labelWidth+barProgress, 0, progIcon.width, barHeight), progIcon);
		
		GUI.EndGroup();
	}
}