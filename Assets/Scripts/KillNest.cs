using UnityEngine;
using System.Collections;

public class KillNest : MonoBehaviour {

	public string collidedTo;

	int nestEnergy = Globals.NEST_INITIAL_ENERGY;
	
	void OnCollisionEnter (Collision collision)
	{
		if (collision.gameObject.tag == collidedTo)
		{
			Globals.score += 100;
			Destroy(collision.gameObject);
			Debug.Log("nestEnergy: " + nestEnergy);
			if (--nestEnergy <= 0) {
				Destroy(gameObject);
			}
		}
	}
}