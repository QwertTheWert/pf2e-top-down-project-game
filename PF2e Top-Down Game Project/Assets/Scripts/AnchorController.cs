using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnchorController : MonoBehaviour {
	public Rigidbody rb;
	[SerializeField] private float cameraSpeed = 5f;
	private Vector3 forward, right;

	void Start() {
		forward = Camera.main.transform.forward;
		forward.y = 0;
		forward = Vector3.Normalize(forward);
		right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;
	}

	void Update() {
		if(Input.anyKey) GetMoveVector();
	}

	void GetMoveVector() {
		Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
		Vector3 rightMovement = right * cameraSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
		Vector3 upMovement = forward * cameraSpeed * Time.deltaTime * Input.GetAxis("Vertical");
		transform.position += rightMovement;
		transform.position += upMovement;
	}
}
