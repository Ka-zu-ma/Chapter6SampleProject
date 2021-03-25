using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour {
	public float bounceForce = 1000.0f;
	// Start is called before the first frame update
	void Start() {

	}

	// Update is called once per frame
	void Update() {

	}

	private void OnTriggerEnter(Collider other) {
		Rigidbody rb = other.GetComponent<Rigidbody>();
		if (rb != null) {
			rb.AddForce(Vector3.up * bounceForce);
		} else {
			HeadLookWalkBounce locomotor = other.GetComponent<HeadLookWalkBounce>();
			if (locomotor != null) {
				locomotor.bounceForce = bounceForce;
			}
		}
	}
}
