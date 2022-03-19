using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnchorController : MonoBehaviour {
	[SerializeField] private float cameraSpeed = 5f;
	[SerializeField] private float edgeSize = 100f;
	[SerializeField] private bool edgeScrollEnabled = false;
	private Vector3 forward, right, direction, movement;
	private Rigidbody rb;


	void Start() {
		rb = GetComponent<Rigidbody>();
		forward = Camera.main.transform.forward;
		forward.y = 0;
		forward = Vector3.Normalize(forward);
		right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;
	}

	void Update() {
		GetMoveVector();
		if (edgeScrollEnabled) EdgeScroll();
	}

	void FixedUpdate() {
		Vector3 rightMovement = right * cameraSpeed * Time.fixedDeltaTime * direction.x;
		Vector3 upMovement = forward * cameraSpeed * Time.fixedDeltaTime * direction.z;
		movement = rightMovement + upMovement;
		rb.MovePosition(rb.position + movement);
	}

	void GetMoveVector() {
		direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
	}

	void EdgeScroll() {
		// Edge Right
		if (Input.mousePosition.x > Screen.width - edgeSize) {
			direction.x = 1;
		}
		// Edge Left
		if (Input.mousePosition.x < edgeSize) {
			direction.x = -1;
		}
		// Edge Up
		if (Input.mousePosition.y > Screen.height - edgeSize) {
			direction.z = 1;
		}
		// Edge Down
		if (Input.mousePosition.y < edgeSize) {
			direction.z = -1;
		}
	}
}
