using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSmoothing : MonoBehaviour
{
    [SerializeField] private Transform anchor;
    [SerializeField] private float smoothSpeed = 5f;

    void FixedUpdate() {
        Vector3 desiredPosition = anchor.position;
        Vector3 smoothedPosition = Vector3.Lerp(
            transform.position, 
            desiredPosition, 
            smoothSpeed * Time.fixedDeltaTime
            );
        transform.position = smoothedPosition;
    }
}
