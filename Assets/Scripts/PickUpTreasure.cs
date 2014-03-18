using UnityEngine;
using System.Collections;

public class PickUpTreasure : MonoBehaviour {

	public string collidedTo;
	
	void OnCollisionEnter (Collision collision)
	{
		if (collision.gameObject.tag == collidedTo)
		{
			Globals.score += 10;
			Destroy(gameObject);
		}
	}
}