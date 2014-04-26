using UnityEngine;
using System.Collections;

public class Globals : MonoBehaviour {
	public const int LAST_LEVEL = 2 + 4; // character screen is "level 2"
	public const int INITIAL_LIVES = 3;
	public const float INITIAL_ENERGY = 125f;
	public const float MAX_ENERGY = INITIAL_ENERGY;
	public const float MAX_FIRE = 50f;
	public const float CAMERA_DISTANCE = 13f;
	public const int ENEMY_INITIAL_ENERGY = 3;
	public const int SUPER_ENEMY_INITIAL_ENERGY = 4;
	public const int NEST_INITIAL_ENERGY = 20;
	public const int SUPER_NEST_INITIAL_ENERGY = 60;
	public const float MINIMUM_HEIGHT = -10; // below this height player screams (and if the height is excessive dies too)
	public const float MENU_BUTTON_WIDTH = 200f;
	public const float MENU_BUTTON_HEIGHT = 50f;
	public const float FAST_FORWARD_SPEED = 15f;

	static public bool dying = false;
	static public int currentLevel = 0; // intro screen (appears only the first time the game runs)
	static public int numLives = INITIAL_LIVES; // FIXME: max 9 lives or else it won't fit into the HUD?
	static public float playerEnergy = INITIAL_ENERGY; //min is 1, max is INITIAL_ENERGY, 0 means death
	static public int score = 0;
	static public Color playerColor = Color.gray;
	static public int weaponType = 2; // the choice of character determines the weapon type
	static public float meleeDistance = 1.4f;
	static public int fireHoldTime = 0;
	static public bool destroyWhileFastForwarding = false;
}
