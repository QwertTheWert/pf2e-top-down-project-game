using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public Func<Vector3> getCameraFollowPositionFunc;
	public void Setup (Func<Vector3> getCameraFollowPositionFunc) {
		this.getCameraFollowPositionFunc = getCameraFollowPositionFunc;
	}
	// Start is called before the first frame update
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		Vector3 cameraFollowPosition = getCameraFollowPositionFunc();
		cameraFollowPosition.y = transform.position.y;

		Vector3 camereMoveDir = (cameraFollowPosition - transform.position).normalized;

		float distance = Vector3.Distance(cameraFollowPosition, transform.position);
		float cameraMoveSpeed = 5f;



		transform.position = transform.position + camereMoveDir * distance * cameraMoveSpeed * Time.deltaTime;

	}
}
