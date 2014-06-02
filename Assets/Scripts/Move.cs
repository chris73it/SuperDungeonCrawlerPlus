using UnityEngine;
using System;
using System.Collections;

public class Move : MonoBehaviour {

	const int RING_Y_BUFFER_SIZE = 8;

	public Camera cam;
	public float speed;
	public float bulletSpeed;
	public GameObject refBullet;
	public AudioClip deathSound;

	public AudioClip fallingSound;
	//public AudioSource fallingSound;
	bool playingFallingSound = false;
	float[] transformPositionY = new float[RING_Y_BUFFER_SIZE];
	int transformPositionYIndex = 0;
	
	Vector3 lastSpeed = new Vector3(0,0,1);
	Vector3 speedDir;

	void InitRingYBufffer() {
		for (int y = 0; y < RING_Y_BUFFER_SIZE; y++) {
			transformPositionY[y] = Globals.MINIMUM_HEIGHT;
		}
	}

	void Start() {
		InitRingYBufffer();
		renderer.material.color = Globals.playerColor;
		refBullet.renderer.material.color = Globals.playerColor;
	}
	
	void FixedUpdate () {
		// detect player is falling: if after 8 consecutives updates it is established that the player is falling with a speed of 1.3f, then play the scream sound
		// NOTE: 1.3f is not a speed, instead it is a number that is propotional to the space covered during the time it took the player to fall for 8 consecutive updates
		// NOTE: it is preferred to use a one shot play because it cannot be interrupted by the "death has you" sound
		transformPositionY[transformPositionYIndex] = transform.position.y;

		if (playingFallingSound == false) {
		    if (transformPositionY[(transformPositionYIndex   -0+RING_Y_BUFFER_SIZE)%RING_Y_BUFFER_SIZE] < transformPositionY[(transformPositionYIndex-1+RING_Y_BUFFER_SIZE)%RING_Y_BUFFER_SIZE]
		    	&& transformPositionY[(transformPositionYIndex-1+RING_Y_BUFFER_SIZE)%RING_Y_BUFFER_SIZE] < transformPositionY[(transformPositionYIndex-2+RING_Y_BUFFER_SIZE)%RING_Y_BUFFER_SIZE]
			    && transformPositionY[(transformPositionYIndex-2+RING_Y_BUFFER_SIZE)%RING_Y_BUFFER_SIZE] < transformPositionY[(transformPositionYIndex-3+RING_Y_BUFFER_SIZE)%RING_Y_BUFFER_SIZE]
			    && transformPositionY[(transformPositionYIndex-3+RING_Y_BUFFER_SIZE)%RING_Y_BUFFER_SIZE] < transformPositionY[(transformPositionYIndex-4+RING_Y_BUFFER_SIZE)%RING_Y_BUFFER_SIZE]
			    && transformPositionY[(transformPositionYIndex-4+RING_Y_BUFFER_SIZE)%RING_Y_BUFFER_SIZE] < transformPositionY[(transformPositionYIndex-5+RING_Y_BUFFER_SIZE)%RING_Y_BUFFER_SIZE]
			    && transformPositionY[(transformPositionYIndex-5+RING_Y_BUFFER_SIZE)%RING_Y_BUFFER_SIZE] < transformPositionY[(transformPositionYIndex-6+RING_Y_BUFFER_SIZE)%RING_Y_BUFFER_SIZE]
			    && transformPositionY[(transformPositionYIndex-6+RING_Y_BUFFER_SIZE)%RING_Y_BUFFER_SIZE] < transformPositionY[(transformPositionYIndex-7+RING_Y_BUFFER_SIZE)%RING_Y_BUFFER_SIZE]
			    && (transformPositionY[(transformPositionYIndex-(RING_Y_BUFFER_SIZE-1)+RING_Y_BUFFER_SIZE)%RING_Y_BUFFER_SIZE] - transformPositionY[(transformPositionYIndex+0+RING_Y_BUFFER_SIZE)%RING_Y_BUFFER_SIZE]) > 1.3f) {
					// NOTE: using 1.3f makes the player scream when it falls throguh the cliff, but not when it falls from the tree or it is hit by a blue nest's disc
					playingFallingSound = true;
					audio.PlayOneShot(fallingSound, 1f);
					//fallingSound.Play();
					StartCoroutine("FallingSound");
			}
		}
		transformPositionYIndex++;
		transformPositionYIndex %= RING_Y_BUFFER_SIZE;
	}
	
	IEnumerator FallingSound() {
		yield return new WaitForSeconds(1f);
		playingFallingSound = false;
		InitRingYBufffer();
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
		if (Globals.currentLevel >= 0+2 && Globals.currentLevel <= 2+4) {
			cam.transform.position = new Vector3(transform.position.x, Globals.CAMERA_DISTANCE, transform.position.z-1);
		} else {
			cam.transform.position = new Vector3(transform.position.x, Globals.CAMERA_DISTANCE+4, transform.position.z-1);
		}

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

		// Reset fire power when the Z button is not pressed (or released)
		if (Input.GetKeyUp(KeyCode.Z)) {

			if (Globals.fireHoldTime == Globals.MAX_FIRE) {
				if (Globals.playerColor == Color.red) { // knight
					if (rigidbody.velocity.magnitude > 0) {
						rigidbody.velocity = speedDir * Globals.FAST_FORWARD_SPEED;
						Globals.destroyWhileFastForwarding = true;
						// TODO: add some effect?
						StartCoroutine("DestroyWhileFastForwarding");
					} else {
						renderer.material.color = Globals.playerColor;
					}
				} else if (Globals.playerColor == Color.green) {  // mage
					Globals.destroyWhileFastForwarding = true;
					// TODO: add some effect?
					StartCoroutine("ShootInAllDirections");
				} else if (Globals.playerColor == Color.cyan) { // assassin
					if (rigidbody.velocity.magnitude > 0) {
						rigidbody.velocity = speedDir * Globals.FAST_FORWARD_SPEED;
						Globals.destroyWhileFastForwarding = true;
						// TODO: add some effect?
						StartCoroutine("DestroyWhileFastForwarding");
					} else {
						renderer.material.color = Globals.playerColor;
					}
				} else if (Globals.playerColor == Color.magenta) { // amazon
					Globals.destroyWhileFastForwarding = true;
					// TODO: add some effect?
					StartCoroutine("ShootInAllDirections");
				} else if (Globals.playerColor == Color.grey) { // place-holder
					Globals.destroyWhileFastForwarding = true;
					// TODO: add some effect?
					StartCoroutine("ShootInAllDirections");
				}
			}

			Globals.fireHoldTime = 0;

			return;
		}

		// Increase fire power when the Z button is being hold down
		if (Input.GetKey(KeyCode.Z)) {
			if (Globals.fireHoldTime < Globals.MAX_FIRE) {
				Globals.fireHoldTime++;
			} else {
				renderer.material.color = Color.white;
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
	
	IEnumerator DestroyWhileFastForwarding() {
		// forward and destroy for one single second
		yield return new WaitForSeconds(1f);
		renderer.material.color = Globals.playerColor;
		Globals.destroyWhileFastForwarding = false;
	}

	IEnumerator ShootInAllDirections() {
		// shoot in all directions for 2 seconds
		for (int times = 0; times < 1; times++) {
			for (int index = 0; index < 5; index++) {

				Vector3 perp2 = Vector3.Cross(Vector3.up, speedDir);
				perp2.Normalize();
				Vector3 perp3 = -perp2;
				Vector3 perp4 = -speedDir;

				Vector3 speedDir1 = Vector3.Lerp(speedDir, perp2,  0.1f * index);
				speedDir1.Normalize();
				Vector3 speedDir2 = Vector3.Lerp(perp2, perp4,  0.1f * index);
				speedDir2.Normalize();
				Vector3 speedDir3 = Vector3.Lerp(perp4, perp3, 0.1f * index);
				speedDir3.Normalize();
				Vector3 speedDir4 = Vector3.Lerp(perp3, speedDir, 0.1f * index);
				speedDir4.Normalize();
				GameObject bullet1 = Instantiate(refBullet, transform.position + 1 * speedDir1, Quaternion.identity) as GameObject;
				bullet1.rigidbody.velocity = speedDir1 * bulletSpeed;
				GameObject bullet2 = Instantiate(refBullet, transform.position + 1 * speedDir2, Quaternion.identity) as GameObject;
				bullet2.rigidbody.velocity = speedDir2 * bulletSpeed;
				GameObject bullet3 = Instantiate(refBullet, transform.position + 1 * speedDir3, Quaternion.identity) as GameObject;
				bullet3.rigidbody.velocity = speedDir3 * bulletSpeed;
				GameObject bullet4 = Instantiate(refBullet, transform.position + 1 * speedDir4, Quaternion.identity) as GameObject;
				bullet4.rigidbody.velocity = speedDir4 * bulletSpeed;
				
				Vector3 perp5 = Vector3.Lerp(speedDir, perp2, 0.5f + 0.1f * index);
				Vector3 perp6 = Vector3.Lerp(perp2, perp4, 0.5f + 0.1f * index);
				Vector3 perp7 = Vector3.Lerp(perp4, perp3, 0.5f + 0.1f * index);
				Vector3 perp8 = Vector3.Lerp(perp3, speedDir, 0.5f + 0.1f * index);
				GameObject bullet5 = Instantiate(refBullet, transform.position + 1 * perp5, Quaternion.identity) as GameObject;
				bullet5.rigidbody.velocity = perp5 * bulletSpeed;
				GameObject bullet6 = Instantiate(refBullet, transform.position + 1 * perp6, Quaternion.identity) as GameObject;
				bullet6.rigidbody.velocity = perp6 * bulletSpeed;
				GameObject bullet7 = Instantiate(refBullet, transform.position + 1 * perp7, Quaternion.identity) as GameObject;
				bullet7.rigidbody.velocity = perp7 * bulletSpeed;
				GameObject bullet8 = Instantiate(refBullet, transform.position + 1 * perp8, Quaternion.identity) as GameObject;
				bullet8.rigidbody.velocity = perp8 * bulletSpeed;

				yield return new WaitForSeconds(0.05f);
			}
		}
		renderer.material.color = Globals.playerColor;
		Globals.destroyWhileFastForwarding = false;
	}

	IEnumerator FlyToHeavenWhileFading() {
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