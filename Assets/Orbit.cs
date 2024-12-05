using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{
    public Transform target; // The Earth object the camera orbits around
    public float distance = 10.0f; // Distance from the target
    public float rotationSpeed = 100.0f; // Speed of rotation
    public float zoomSpeed = 2.0f; // Speed of zooming in/out
    public float minDistance = 5.0f; // Minimum zoom distance
    public float maxDistance = 20.0f; // Maximum zoom distance

    private float currentRotationX = 0.0f; // Rotation around the X-axis (up/down)
    private float currentRotationY = 0.0f; // Rotation around the Y-axis (left/right)

    void Start()
    {
        // Initialize the camera's position based on the target's position and distance
        if (target != null)
        {
            transform.position = target.position - transform.forward * distance;
        }
    }

    void Update()
    {
        if (target == null) return;

        // Rotate camera using mouse drag
        if (Input.GetMouseButton(1)) // Right mouse button
        {
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");

            currentRotationY += mouseX * rotationSpeed * Time.deltaTime;
            currentRotationX -= mouseY * rotationSpeed * Time.deltaTime;

            // Clamp the X rotation to prevent flipping over
            currentRotationX = Mathf.Clamp(currentRotationX, -85f, 85f);
        }

        // Zoom in/out using the mouse scroll wheel
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        distance -= scroll * zoomSpeed;
        distance = Mathf.Clamp(distance, minDistance, maxDistance);

        // Update the camera's position and rotation
        Quaternion rotation = Quaternion.Euler(currentRotationX, currentRotationY, 0);
        Vector3 offset = rotation * Vector3.back * distance;
        transform.position = target.position + offset;
        transform.LookAt(target);
    }
}


