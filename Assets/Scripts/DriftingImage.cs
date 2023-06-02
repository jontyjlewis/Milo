using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriftingImage : MonoBehaviour
{
    public float driftSpeed = 1f;
    public float driftAcceleration = 0.1f;
    public float boundaryX = 5f;
    public float boundaryY = 3f;
    public float minRadius = 0.1f;
    public float maxRadius = 1f;
    public float driftFrequency = 1f;

    private Vector3 initialPosition;
    private float angle;
    private float currentDriftSpeed;
    // private float currentRadius;

    void Start()
    {
        initialPosition = transform.position;
        currentDriftSpeed = driftSpeed;
        // currentRadius = minRadius;
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate the angle based on time and frequency
        angle += driftFrequency * Time.deltaTime;

        // Calculate the radius based on the current drift speed
        // float currentRadius = driftRadius + currentDriftSpeed/2;
        float currentRadius = Mathf.Lerp(minRadius, maxRadius, currentDriftSpeed);
        

        // Calculate the new position based on the drift speed and spiral motion
        float x = Mathf.Cos(angle) * currentRadius;
        float y = Mathf.Sin(angle) * currentRadius;
        Vector3 driftOffset = new Vector3(x, y, 0f);
        Vector3 newPosition = initialPosition + driftOffset;

        // Ensure the new position stays within the specified boundaries
        newPosition.x = Mathf.Clamp(newPosition.x, initialPosition.x - boundaryX, initialPosition.x + boundaryX);
        newPosition.y = Mathf.Clamp(newPosition.y, initialPosition.y - boundaryY, initialPosition.y + boundaryY);

        // Update the position of the image
        transform.position = newPosition;

        // increase drift speed over time
        currentDriftSpeed += driftAcceleration * Time.deltaTime;
    }
}
