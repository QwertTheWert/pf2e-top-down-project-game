using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAnchorMovement : MonoBehaviour {
	[SerializeField] private float moveSpeed = 5f;
	[SerializeField] private float edgeSize = 100f;
	[SerializeField] private bool enableEdgeScroll = true;
	[SerializeField] private Rigidbody rb;

	Vector3 movement;

	void Update() {
		// Input
		movement.x = Input.GetAxisRaw("Horizontal");
		movement.z = Input.GetAxisRaw("Vertical");

		if(Input.GetKeyDown(KeyCode.Space)) {
			enableEdgeScroll = !enableEdgeScroll;
		}
		
		if (enableEdgeScroll) {
			EdgeScroll();
		}
	}

	void FixedUpdate() {
		// Movement
		rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
	}

	void EdgeScroll() {
		// Edge Right
		if (Input.mousePosition.x > Screen.width - edgeSize) {
			movement.x = 1;
		}
		// Edge Left
		if (Input.mousePosition.x < edgeSize) {
			movement.x = -1;
		}
		// Edge Up
		if (Input.mousePosition.y > Screen.height - edgeSize) {
			movement.z = 1;
		}
		// Edge Down
		if (Input.mousePosition.y < edgeSize) {
			movement.z = -1;
		}
	}
}
