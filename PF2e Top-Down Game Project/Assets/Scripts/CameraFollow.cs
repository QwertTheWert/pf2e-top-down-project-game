using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public float cameraMoveSpeed = 10f;
	public float cameraZoomSpeed = 1f;
		
	private Camera myCamera;
	private Func<float> GetCameraZoomFunc;

	public Func<Vector3> GetCameraFollowPositionFunc;
	public void Setup (Func<Vector3> GetCameraFollowPositionFunc, Func<float> GetCameraZoomFunc) {
		this.GetCameraFollowPositionFunc = GetCameraFollowPositionFunc;
		this.GetCameraZoomFunc = GetCameraZoomFunc;
	}

	// Start
	private void Start() {
		myCamera = transform.GetComponent<Camera>();
	}

	public void SetCameraFollowPosition(Vector3 cameraFollowPosition) {
		SetGetCameraFollowPositionFunc(() => cameraFollowPosition);
	}
	public void SetGetCameraFollowPositionFunc(Func<Vector3> GetCameraFollowPositionFunc) {
		this.GetCameraFollowPositionFunc = GetCameraFollowPositionFunc;
	}

	public void SetCameraZoom(float cameraZoom) {
		SetGetCameraZoomFunc(() => cameraZoom);
	}
	public void SetGetCameraZoomFunc(Func<float> GetCameraZoomFunc) {
		this.GetCameraZoomFunc = GetCameraZoomFunc;
	}

	// Update is called once per frame
	void FixedUpdate() {
		HandleMovement();
		HandleZoom();
	}

	private void HandleMovement() {
		Vector3 cameraFollowPosition = GetCameraFollowPositionFunc();
		cameraFollowPosition.y = transform.position.y;

		Vector3 cameraMoveDir = (cameraFollowPosition - transform.position).normalized;

		float distance = Vector3.Distance(cameraFollowPosition, transform.position);

		transform.position += cameraMoveDir * distance * cameraMoveSpeed * Time.fixedDeltaTime;
	}

	private void HandleZoom() {
		float cameraZoom = GetCameraZoomFunc();

		float cameraZoomDifference = Mathf.Clamp(cameraZoom - myCamera.orthographicSize,-3,5);

		myCamera.orthographicSize += cameraZoomDifference * cameraZoomSpeed * Time.fixedDeltaTime;
	}
}
