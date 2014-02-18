using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

	public Camera cam;
	public float speed;
	public float bulletSpeed;
	public GameObject refBullet;
	Vector3 lastSpeed = new Vector3(0,0,-1);

	// Update is called once per frame
	void Update () {
		// Get the horizontal and vertical axis delta movements.
		// By default they are mapped to the arrow keys.
		// The value is in the range -1 to 1
		// Move translation along the object's x-axis and z-axis
		float translationX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
		float translationZ = Input.GetAxis("Vertical") * speed * Time.deltaTime;
		transform.position += new Vector3(translationX, 0, translationZ);
		
		// Move camera to follow the player while staying at hight 15
		cam.transform.position = new Vector3(transform.position.x, 15, transform.position.z-2);

		// Calculate the player direction
		Vector3 speedVersor = Vector3.ClampMagnitude(new Vector3(translationX, 0, translationZ), 1);

		// Shoot when the Z button is being pressed
		if (speedVersor.magnitude == 0) {
			speedVersor = lastSpeed;
		} else {
			speedVersor.Normalize();
			lastSpeed = speedVersor;
		}
		if (Input.GetKeyDown(KeyCode.Z)) {
			GameObject bullet = Instantiate(refBullet, transform.position + 1 * speedVersor, transform.rotation) as GameObject;
			bullet.rigidbody.velocity = speedVersor * bulletSpeed;
		}
	}
}