﻿using UnityEngine;
using System.Collections;

public class PickUpPinkKey : MonoBehaviour {

	static public bool gotPinkKey = false;

	public string collidedTo;

	GameObject centralPillar;

	void Start() {
		centralPillar = GameObject.Find("CentralPillar");
	}

	void OnCollisionEnter (Collision collision) {
		Debug.Log ("OnCollisionEnter: " + collision.gameObject.tag + " - " + collidedTo);
		if (collision.gameObject.tag == collidedTo)
		{
			gotPinkKey = true;
			if (centralPillar) Debug.Log("NOT NULL: " + centralPillar);
			Destroy(centralPillar);
			Destroy(gameObject);
		}
	}
}