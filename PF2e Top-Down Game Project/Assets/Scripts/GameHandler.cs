using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
	[SerializeField] private CameraFollow cameraFollow;
	[SerializeField] private Transform playerTransform;
	// [SerializeField] private int targetFrameRate = 60;

	[SerializeField] private float zoom = 5;
	private bool zoomIn;
	private bool zoomOut;



	// Start is called before the first frame update
	void Start()
	{
		// cameraFollow.set
		cameraFollow.Setup(() => playerTransform.position, () => zoom);
	}

	void Update() {
		// Zoom Key Input
		zoomIn = Input.GetKey("-");
		zoomOut = Input.GetKey("=");
	}

	void FixedUpdate() {
		// Update Zoom
		if (zoomIn && !zoomOut) ZoomIn();
		if (!zoomIn && zoomOut) ZoomOut();
	}

	private void ZoomIn() {
		zoom -= 1f;
		if (zoom < 5f) zoom = 5f;
	}

	private void ZoomOut() {
		zoom += 1f;
		if (zoom > 40f) zoom = 40f;
	}
}
