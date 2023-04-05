using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    private Vector3 lastPosition;
    public float maxPosition = 10f; // max position of the camera on the Y axis
    public float moveSpeed = 1f;

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            lastPosition = Input.mousePosition;
        }
        if(Input.GetMouseButton(0))
        {
            Vector3 delta = Input.mousePosition - lastPosition;
            float newY = transform.position.y - delta.y * Time.deltaTime * moveSpeed;
            if(newY < -maxPosition)
            {
                newY = -maxPosition;
            }
            if(newY > maxPosition)
            {
                newY = maxPosition;
            }
            transform.position = new Vector3(transform.position.x, newY, transform.position.z);
            lastPosition = Input.mousePosition;
        }
    }
}
