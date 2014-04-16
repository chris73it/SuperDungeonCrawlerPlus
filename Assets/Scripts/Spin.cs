using UnityEngine;
using System.Collections;

public class Spin : MonoBehaviour {
	
	void Update () {
		transform.Rotate(Vector3.up * Time.deltaTime * 100);
		transform.Rotate(Vector3.forward * Time.deltaTime * 100);
		transform.Rotate(Vector3.left * Time.deltaTime * 100);
	}
}
