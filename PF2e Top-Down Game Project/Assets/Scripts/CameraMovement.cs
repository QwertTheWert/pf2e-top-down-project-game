using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

	public float moveSpeed = 5f;
	public float scrollSpeed = 5f;
	public Rigidbody rb;

	Vector3 movement;

	// Update is called once per frame
	void Update() {
		// Input
		movement.x = Input.GetAxisRaw("Horizontal");
		movement.z = Input.GetAxisRaw("Vertical");
		
	}

	void FixedUpdate() {
		// Movement
		rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
	}
}
