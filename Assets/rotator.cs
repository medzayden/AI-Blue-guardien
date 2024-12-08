using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotator : MonoBehaviour
{


    public float rotationSpeed = 30f;  // Rotation speed in degrees per second

    void Update()
    {
        // Rotate the object around its Y-axis (up axis)
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }
}
