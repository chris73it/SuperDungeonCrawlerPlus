using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

	public Camera cam;
	public float speed;
	public float bulletSpeed;
	public GameObject refBullet;
	public AudioClip deathSound;

	Vector3 lastSpeed = new Vector3(0,0,1);
	Vector3 speedDir;

	void Start() {
		renderer.material.color = Globals.playerColor;
		refBullet.renderer.material.color = Globals.playerColor;
	}

	void Update () {
		// Get the horizontal and vertical axis delta movements.
		// By default they are mapped to the arrow keys.
		// The value is in the range -1 to 1
		// Move along the object's x-axis and z-axis
		// Move camera to follow the player while staying at the same distance
		float translationX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
		float translationZ = Input.GetAxis("Vertical") * speed * Time.deltaTime;
		transform.position += new Vector3(translationX, 0, translationZ);
		cam.transform.position = new Vector3(transform.position.x, Globals.CAMERA_DISTANCE, transform.position.z-1);

		// when player falls exit
		if (transform.position.y < Globals.MINIMUM_HEIGHT && Globals.dying == false) {
			Globals.dying = true;
			audio.PlayOneShot(deathSound, 1f);
			Globals.numLives--;
			StartCoroutine("FlyToHeavenWhileFading");
		}

		// while the player is "flying to heaven", it shouldn't be allowed to shoot
		if (Globals.dying == true) {
			return;
		}

		// Calculate the player direction
		// Remember the last direction player was moving towards
		speedDir = Vector3.ClampMagnitude(new Vector3(translationX, 0, translationZ), 1);
		if (speedDir.magnitude == 0) {
			speedDir = lastSpeed;
		} else {
			speedDir.Normalize();
			lastSpeed = speedDir;
		}

		// Reset fire power when the Z button is not pressed
		if (Input.GetKeyUp(KeyCode.Z)) {

			if (Globals.fireHoldTime == Globals.MAX_FIRE) {
				if (Globals.playerColor == Color.red) { // knight
					if (rigidbody.velocity.magnitude > 0) {
						rigidbody.velocity = speedDir * Globals.FAST_FORWARD_SPEED; // fast forward and destroy!
					}
					Globals.destroyWhileFastForwarding = true;
					StartCoroutine("DestroyWhileFastForwarding");
				} else if (Globals.playerColor == Color.green) {  // mage

				} else if (Globals.playerColor == Color.cyan) { // assassin

				}  else if (Globals.playerColor == Color.magenta) { // amazon

				}
			}

			Globals.fireHoldTime = 0;

			return;
		}

		// Increase fire power when the Z button is being hold down
		if (Input.GetKey(KeyCode.Z)) {
			if (Globals.fireHoldTime < Globals.MAX_FIRE) {
				Globals.fireHoldTime++;
			}
		}

		// Shoot when the Z button is being pressed
		if (Input.GetKeyDown(KeyCode.Z)) {

			audio.Play();

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

			if (Globals.weaponType == 1 || Globals.weaponType == 2 || Globals.weaponType == 3) {
				GameObject bullet = Instantiate(refBullet, transform.position + 1 * speedDir, Quaternion.identity) as GameObject;
				bullet.rigidbody.velocity = speedDir * bulletSpeed;
			}
			if (Globals.weaponType == 2 || Globals.weaponType == 3) {
				GameObject bullet2 = Instantiate(refBullet, transform.position + 1 * speedDir2, Quaternion.identity) as GameObject;
				bullet2.rigidbody.velocity = speedDir2 * bulletSpeed;
				GameObject bullet3 = Instantiate(refBullet, transform.position + 1 * speedDir3, Quaternion.identity) as GameObject;
				bullet3.rigidbody.velocity = speedDir3 * bulletSpeed;
			}
			if (Globals.weaponType == 3) {
				GameObject bullet4 = Instantiate(refBullet, transform.position + 1 * speedDir4, Quaternion.identity) as GameObject;
				bullet4.rigidbody.velocity = speedDir4 * bulletSpeed;
				GameObject bullet5 = Instantiate(refBullet, transform.position + 1 * speedDir5, Quaternion.identity) as GameObject;
				bullet5.rigidbody.velocity = speedDir5 * bulletSpeed; 
			}
		}
	}
	
	IEnumerator DestroyWhileFastForwarding () {
		// forward and destroy for one single second
		yield return new WaitForSeconds(1f);
		Globals.destroyWhileFastForwarding = false;
	}

	IEnumerator FlyToHeavenWhileFading () {
		Vector3 newPosition = transform.position;
		Color c = renderer.material.color;
		float a, y;
		
		for (a = 80.0f, y = 5.0f; y < 500.0f; y+=5.0f) {
			
			c.a = a/100.0f;
			renderer.material.color = c;
			if (a > 0.01f) { a--; } else { a = 0.0f; }
			
			newPosition.y += y/500.0f;
			transform.position = newPosition;
			
			yield return new WaitForSeconds(0.016f);
		}
		Globals.dying = false;
		if (Globals.numLives <= 0) {
			Application.LoadLevel("Fail_Screen");
		} else {
			PickUpBlueKey.gotBlueKey = false; // FIXME
			PickUpRedKey.gotRedKey = false; // FIXME
			PickUpGreenKey.gotGreenKey = false; // FIXME
			PickUpPinkKey.gotPinkKey = false; // FIXME
			Application.LoadLevel(Globals.currentLevel);
		}
	}
}