using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCamera : MonoBehaviour {

    public Camera FirstViewCam;

	private void FixedUpdate() {
		UpdateRotation();
	}

	private void UpdateRotation() {
		Vector3 cameraPosition = FirstViewCam.transform.position;
		this.transform.LookAt(cameraPosition);
		this.transform.localEulerAngles = new Vector3(0, this.transform.localEulerAngles.y - 180, 0);
	}
}
