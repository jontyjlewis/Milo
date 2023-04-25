using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    // Variabls to control the camera movement
    public float speed = 5f;
    public bool isMoving = false;
    public bool canMove = true;

    // Variables to defien the boundaries of camera movement
    public float yMin = 0f;
    public float yMax = 10f;

    // Variables to define the postion where the check needs to be performed
    public float checkPosition = 5f;

    // Variables to hold the initial click position and the current position
    private Vector3 dragOrigin;
    private Vector3 currentPosition;
    private float initialPositionY;

    private void Start()
    {
        // Store the inital Y-position of the camera/container
        initialPositionY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canMove)
        {
            // Set the initial drag position
            dragOrigin = Input.mousePosition;
            isMoving = true;
        }

        if (Input.GetMouseButton(0) && isMoving)
        {
            // Calculate the current position based on the drag distance
            Vector3 difference = Input.mousePosition - dragOrigin;
            currentPosition = transform.position + new Vector3(0f, -difference.y * speed * Time.deltaTime, 0f);

            // Check if the currentPosition is within the boundaries and not above initial position
            if (currentPosition.y >= initialPositionY && currentPosition.y <= checkPosition)
            {
                // Check if the camera needs to stop at the check position
                if (currentPosition.y <= checkPosition)
                {
                    // PERFORM CHECK HERE
                    // If check is successful, allow the camera to move
                    canMove = true;
                }
                else
                {
                    canMove = false;
                    Debug.Log(currentPosition.y);
                }

                // Move the camera to the current position
                transform.position = currentPosition;
                dragOrigin = Input.mousePosition;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            isMoving = false;
        }
    }
}
