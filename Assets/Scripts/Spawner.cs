﻿using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public float interval;
	public GameObject creature;

	void Start () {
		StartCoroutine("Spawn");
	}

	IEnumerator Spawn () {
		for (;;) {
			Vector2 newPosition2D = Random.insideUnitCircle;
			Vector3 newPosition3D = transform.position;
			newPosition3D.x += newPosition2D.x;
			newPosition3D.y = 3;
			newPosition3D.z += newPosition2D.y;
			Instantiate(creature, newPosition3D, transform.rotation);
			yield return new WaitForSeconds(interval);
		}
	}
}
