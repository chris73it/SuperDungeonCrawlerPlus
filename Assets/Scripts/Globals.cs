using UnityEngine;
using System.Collections;

public class Globals : MonoBehaviour {
	public const int LAST_LEVEL = 2 + 6; // character screen is "level 2"
	public const int INITIAL_LIVES = 1;
	public const float INITIAL_ENERGY = 100f;
	public const float CAMERA_DISTANCE = 15f;
	public const int NEST_INITIAL_ENERGY = 50;
	public const float MENU_BUTTON_WIDTH = 200f;
	public const float MENU_BUTTON_HEIGHT = 50f;

	static public int currentLevel = 0; // intro screen (appears only the first time the game runs)
	static public int numLives = INITIAL_LIVES; // FIXME: max 9 lives?
	static public float playerEnergy = 100f; //min is 1, max 100, 0 means death
	static public int score = 0;
	static public Color playerColor;
}
