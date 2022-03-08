using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
	[SerializeField] private CameraFollow cameraFollow;
	[SerializeField] private Transform playerTransform;

	// Start is called before the first frame update
	void Start()
	{
		// cameraFollow.set
		Debug.Log("GameHandler.Start");
		cameraFollow.Setup(() => playerTransform.position);
	}

	// Update is called once per frame
	void Update()
	{
		
	}
}
