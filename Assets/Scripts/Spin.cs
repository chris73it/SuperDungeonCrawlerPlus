using UnityEngine;
using System.Collections;

public class Spin : MonoBehaviour {
	
	void Update () {
		transform.Rotate(Vector3.up * Time.deltaTime * 100);
	}
}
