using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingPlatform : ObstacleBehaviour
{
    public float rotationSpeed = 20f; // Speed of rotation
    public float returnSpeed = 5f;    // Speed to return to the original rotation

    private Quaternion originalRotation; // Store the original rotation

    private void Start()
    {
        // Store the initial rotation when the script starts
        originalRotation = transform.rotation;
    }

    public override void EnableObstacle()
    {
        // This method will be triggered when the obstacle is enabled
    }

    public override void DisableObstacle()
    {
        // This method will be triggered when the obstacle is disabled
    }

    private void Update()
    {
        if (isTriggered)
        {
            // Rotate the platform when triggered
            transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
        }
        else
        {
            // Smoothly rotate back to the original rotation
            transform.rotation = Quaternion.Slerp(transform.rotation, originalRotation, returnSpeed * Time.deltaTime);
        }
    }
}