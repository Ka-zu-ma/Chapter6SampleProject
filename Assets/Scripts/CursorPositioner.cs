using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorPositioner : MonoBehaviour {
	private float defaultPosZ;
	public Transform centerEyeAnchor;

	// Start is called before the first frame update
	void Start() {
		defaultPosZ = transform.localPosition.z;
	}

	// Update is called once per frame
	void Update() {
		Ray ray;
		ray = new Ray(centerEyeAnchor.position, centerEyeAnchor.forward);
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit)) {
			transform.localPosition = new Vector3(0, 0, hit.distance);
		} else {
			transform.localPosition = new Vector3(0, 0, defaultPosZ);
		}
	}
}
