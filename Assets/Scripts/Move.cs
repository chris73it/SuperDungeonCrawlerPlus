using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

	public Camera cam;
	public float speed;
	public float bulletSpeed;
	public GameObject refBullet;

	private Vector3 lastSpeed = new Vector3(0,0,-1);

	void Start() {
		renderer.material.color = Globals.playerColor;
	}

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
		Vector3 speedDir = Vector3.ClampMagnitude(new Vector3(translationX, 0, translationZ), 1);

		// Remember the last direction player was moving towards
		if (speedDir.magnitude == 0) {
			speedDir = lastSpeed;
		} else {
			speedDir.Normalize();
			lastSpeed = speedDir;
		}

		// Shoot when the Z button is being pressed
		if (Input.GetKeyDown(KeyCode.Z)) {
			Vector3 perp1 = Vector3.Cross(Vector3.up, speedDir);
			perp1.Normalize();
			Vector3 perp2 = -perp1;
			Vector3 speedDir2 = Vector3.Lerp(speedDir, perp1, 0.11f);
			speedDir2.Normalize();
			Vector3 speedDir3 = Vector3.Lerp(speedDir, perp2, 0.11f);
			speedDir3.Normalize();
			Vector3 speedDir4 = Vector3.Lerp(speedDir, perp1, 0.22f);
			speedDir2.Normalize();
			Vector3 speedDir5 = Vector3.Lerp(speedDir, perp2, 0.22f);
			speedDir3.Normalize();

			if (Shortcuts.weaponType == 1 || Shortcuts.weaponType == 2 || Shortcuts.weaponType == 3) {
				GameObject bullet = Instantiate(refBullet, transform.position + 1 * speedDir, transform.rotation) as GameObject;
				bullet.rigidbody.velocity = speedDir * bulletSpeed;
			}
			if (Shortcuts.weaponType == 2 || Shortcuts.weaponType == 3) {
				GameObject bullet2 = Instantiate(refBullet, transform.position + 1 * speedDir2, transform.rotation) as GameObject;
				bullet2.rigidbody.velocity = speedDir2 * bulletSpeed;
				GameObject bullet3 = Instantiate(refBullet, transform.position + 1 * speedDir3, transform.rotation) as GameObject;
				bullet3.rigidbody.velocity = speedDir3 * bulletSpeed;
			}
			if (Shortcuts.weaponType == 3) {
				GameObject bullet4 = Instantiate(refBullet, transform.position + 1 * speedDir4, transform.rotation) as GameObject;
				bullet4.rigidbody.velocity = speedDir4 * bulletSpeed;
				GameObject bullet5 = Instantiate(refBullet, transform.position + 1 * speedDir5, transform.rotation) as GameObject;
				bullet5.rigidbody.velocity = speedDir5 * bulletSpeed; 
			}
		}
	}
}