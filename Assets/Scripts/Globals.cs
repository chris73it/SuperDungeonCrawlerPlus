using UnityEngine;
using System.Collections;

public class Globals : MonoBehaviour {
	static public int numLives = 3; // FIXME: max 9 lives?
	static public int currentLevel = 0; // into level
	static public float playerEnergy = 100f; //min is 1, max 100, 0 means death
}
