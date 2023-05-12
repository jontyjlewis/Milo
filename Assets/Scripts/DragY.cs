using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragY : MonoBehaviour
{
    private Vector3 lastPosition;
    public float moveSpeed = 1f;
    public float scrollSpeed = 10f;

    [SerializeField] private GameObject lastPanel;
    private float initialPositionY;
    private float endPositionY;

    private void Start()
    {
        // Store the initial Y-position of the camera/container
        initialPositionY = transform.position.y;
        endPositionY = lastPanel.transform.position.y;
        //Debug.Log(endPositionY);
    }

    void Update()
    {
        // For Scrollwheel
        // get the scroll wheel input
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");

        // move up or down based on input
        Vector3 position = transform.position;
        position.y -= scrollInput * scrollSpeed;
        
        if(position.y <= initialPositionY)
        {
            position.y = initialPositionY;
        }
        else if (position.y >= -endPositionY)
        {
            position.y = -endPositionY;
        }
        transform.position = position;


        // For Click and Drag
        if (Input.GetMouseButtonDown(0))
        {
            lastPosition = Input.mousePosition;
        }
        if(Input.GetMouseButton(0))
        {
            Vector3 delta = Input.mousePosition - lastPosition;
            float newY = transform.position.y - delta.y * Time.deltaTime * (-moveSpeed);
            
            if (newY >= initialPositionY && newY <= -endPositionY)
            {
                transform.position = new Vector3(transform.position.x, newY, transform.position.z);
                lastPosition = Input.mousePosition;
                //Debug.Log(newY);
            }            
        }
    }
}
