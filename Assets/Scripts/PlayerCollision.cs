using UnityEngine;
using System.Collections;

public class PlayerCollision : MonoBehaviour {

	public string collidedTo;

	void OnCollisionEnter (Collision collision)
	{
		if (collision.gameObject.tag == collidedTo)
		{
			StartCoroutine("FlyToHeaven");
			StartCoroutine("Fade");
		}
	}
	
	IEnumerator FlyToHeaven() {
		Vector3 newPosition = transform.position;
		
		for (float y = 1.0f; y < 200f; y+=1.0f) {
			newPosition.y += y/100.0f;
			transform.position = newPosition;
			
			yield return new WaitForSeconds(0.016f);
		}
		Destroy (gameObject);
	}

	IEnumerator Fade() {
		Color c = renderer.material.color;

		for (float a = 80.0f; a >= 0.0f; a--) {
			c.a = a/100.0f;
			renderer.material.color = c;
			yield return new WaitForSeconds(0.016f);
		}
	}
}