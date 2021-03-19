using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LookMoveTo : MonoBehaviour {
	public GameObject ground;
	public Transform centerEyeAnchor;
	RaycastHit[] hits;
	public Transform infoBubble;
	private Text infoText;

	void Start() {
		if (infoBubble != null) {
			infoText = infoBubble.Find("Text").GetComponent<Text>();
		}
	}

	// Update is called once per frame
	void Update() {
		Ray ray;
		GameObject hitObject;

		ray = new Ray(centerEyeAnchor.position, centerEyeAnchor.forward);
		hits = Physics.RaycastAll(ray);

		for (int i = 0; i < hits.Length; i++) {
			RaycastHit hit = hits[i];
			hitObject = hit.collider.gameObject;
			if (hitObject == ground) {
				//Debug.Log("HIt(x,y,z): " + hit.point.ToString("F2"));

				if (infoBubble != null) {
					infoText.text = "X:" + hit.point.x.ToString("F2") + ",Z" + hit.point.z.ToString("F2");

					infoBubble.LookAt(centerEyeAnchor.position);
					infoBubble.Rotate(0.0f, 180.0f, 0.0f);
				}
				transform.position = hit.point;
			}
		}
	}
}
