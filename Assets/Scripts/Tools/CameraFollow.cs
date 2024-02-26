using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Targets")]
    public Transform targetPos;
    public Transform cameraPos;
 
    [Header("Camera Settings")]
    public float followDistance = 10f;
    public float elevationAngle = 2f;
    public float orbitalAngle = 2f;

    [Header("Smoothing Settings")]
    public bool isMovementSmoothing = true;
    public bool isRotationSmoothing = false;

    public float movementSmoothing = 0.25f;
    public float rotationSmoothing = 5.0f;

    private Vector3 _desiredPosition;

    private void FixedUpdate()
    {
        // Check for Valid Target
        if (targetPos != null)
            _desiredPosition = targetPos.position + targetPos.TransformDirection(Quaternion.Euler(elevationAngle, orbitalAngle, 0f) * (new Vector3(0, 0, -followDistance)));
        else
            Debug.LogError("Camera Target is NULL");

        // Movement Smoothing
        if (isMovementSmoothing)
            cameraPos.position = Vector3.Lerp(cameraPos.position, _desiredPosition, Time.deltaTime * 5.0f);
        else
            cameraPos.position = _desiredPosition;

        // Rotation Smoothing
        if (isRotationSmoothing)
            cameraPos.rotation = Quaternion.Lerp(cameraPos.rotation, Quaternion.LookRotation(targetPos.position - cameraPos.position), rotationSmoothing * Time.deltaTime);
        else
            cameraPos.LookAt(targetPos);
    }
}
