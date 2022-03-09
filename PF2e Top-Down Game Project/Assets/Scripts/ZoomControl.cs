using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomControl : MonoBehaviour
{
    private float zoom = 5f;
	private float minZoom = 2f;
	private float maxZoom = 10f;
	[SerializeField] private float zoomSpeed = 0.5f;
	private Camera myCamera;

    void Start() {
        myCamera = GetComponent<Camera>();
    }

    void Update()
    {
        GetZoomControl();
    }

    void FixedUpdate() {
        HandleZoom();
    }

    void GetZoomControl() {
        if (Input.GetKey(KeyCode.KeypadPlus)) {
			zoom -= zoomSpeed;
		}
		if (Input.GetKey(KeyCode.KeypadMinus)) {
			zoom += zoomSpeed;
		}

		if (Input.mouseScrollDelta.y > 0) {
			zoom -= zoomSpeed * 10;
		}
		if (Input.mouseScrollDelta.y < 0) {
			zoom += zoomSpeed * 10;
		}

		zoom = Mathf.Clamp(zoom, minZoom, maxZoom);
    }
    
    private void HandleZoom() {
		float cameraZoomDifference = zoom - myCamera.orthographicSize;
		myCamera.orthographicSize += cameraZoomDifference * zoomSpeed * Time.fixedDeltaTime;
	}
}
