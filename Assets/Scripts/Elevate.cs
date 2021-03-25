using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevate : MonoBehaviour {
	public float minHeight = 1.2f;
	public float maxHeight = 8.0f;
	public float velocity = 1;

	// Start is called before the first frame update
	void Start() {
		float y = transform.position.y;
		y += velocity * Time.deltaTime;
		if (y > maxHeight) {
			y = maxHeight;
			velocity = -velocity;
		}

		if (y < minHeight) {
			y = minHeight;
			velocity = -velocity;
		}

		transform.position = new Vector3(transform.position.x, y, transform.position.z);
	}

	// Update is called once per frame
	void Update() {

	}
}
