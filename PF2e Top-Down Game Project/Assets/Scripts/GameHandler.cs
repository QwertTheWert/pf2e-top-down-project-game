using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
	[SerializeField] private CameraFollow cameraFollow;
	[SerializeField] private Transform playerTransform;
	// [SerializeField] private int targetFrameRate = 60;
	[SerializeField] private float zoom = 5f;
	[SerializeField] private float zoomChangeAmount = 0.1f;
	[SerializeField] private float minZoom = 5f;
	[SerializeField] private float maxZoom = 40f;

	// Start is called before the first frame update
	void Start() {
		// cameraFollow.set
		cameraFollow.Setup(() => playerTransform.position, () => zoom);
	}

	void FixedUpdate() {
		// Zoom Key Input
		if (Input.GetKey(KeyCode.KeypadPlus)) {
			zoom -= zoomChangeAmount * Time.fixedDeltaTime;
		}
		if (Input.GetKey(KeyCode.KeypadMinus)) {
			zoom += zoomChangeAmount * Time.fixedDeltaTime;
		}

		if (Input.mouseScrollDelta.y > 0) {
			zoom -= zoomChangeAmount * Time.fixedDeltaTime * 10;
		}
		if (Input.mouseScrollDelta.y < 0) {
			zoom += zoomChangeAmount * Time.fixedDeltaTime * 10;
		}

		zoom = Mathf.Clamp(zoom, minZoom, maxZoom);
	}	
}