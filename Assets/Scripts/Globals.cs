using UnityEngine;
using System.Collections;

public class Globals : MonoBehaviour {
	public const int INITIAL_LIVES = 1;

	static public int numLives = INITIAL_LIVES; // FIXME: max 9 lives?
	static public int currentLevel = 0; // main menu level
	static public float playerEnergy = 100f; //min is 1, max 100, 0 means death
	static public int score = 0;
	static public Color playerColor;
}
