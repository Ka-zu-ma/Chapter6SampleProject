using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlippinDashboard : MonoBehaviour {
	private HeadGesture gesture;
	private GameObject dashboard;
	private bool isOpen = true;
	private Vector3 startRotation;
	private float timer = 0.0f;
	private float timerReset = 2.0f;

	// Start is called before the first frame update
	void Start() {
		gesture = GetComponent<HeadGesture>();
		dashboard = GameObject.Find("Dashboard");
		startRotation = dashboard.transform.eulerAngles;
		CloseDashboard();
	}

	// Update is called once per frame
	void Update() {
		if (gesture.isMovingDown) {
			OpenDashboard();
		} else if (!gesture.isFacingDown) {
			timer -= Time.deltaTime;
			if (timer <= 0.0f) {
				CloseDashboard();
			}
		} else {
			timer = timerReset;
		}
	}

	private void CloseDashboard() {
		if (isOpen) {
			dashboard.transform.eulerAngles = new Vector3(100.0f, startRotation.y, startRotation.z);
			isOpen = false;
		}
	}

	private void OpenDashboard() {
		if (isOpen) {
			dashboard.transform.eulerAngles = startRotation;
			isOpen = true;
		}
	}
}
