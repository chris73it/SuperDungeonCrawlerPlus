using UnityEngine;
using System.Collections;

public class Globals : MonoBehaviour {
	public const int LAST_LEVEL = 2 + 4; // character screen is "level 2"
	public const int INITIAL_LIVES = 2;
	public const float INITIAL_ENERGY = 300f;
	public const float CAMERA_DISTANCE = 13f;
	public const int NEST_INITIAL_ENERGY = 40;
	public const float MINIMUM_HEIGHT = -10; // below this height player dies
	public const float MENU_BUTTON_WIDTH = 200f;
	public const float MENU_BUTTON_HEIGHT = 50f;

	static public bool dying = false;
	static public int currentLevel = 0; // intro screen (appears only the first time the game runs)
	static public int numLives = INITIAL_LIVES; // FIXME: max 9 lives?
	static public float playerEnergy = INITIAL_ENERGY; //min is 1, max is INITIAL_ENERGY, 0 means death
	static public int score = 0;
	static public Color playerColor;
}
