using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragX : MonoBehaviour
{
    private Vector3 lastPosition;
    public float moveSpeed = 1f;

    [SerializeField] private GameObject endPoint;
    private float initialPositionX;
    private float endPositionX;
    [SerializeField] private GameObject unlocked;

    // Start is called before the first frame update
    void Start()
    {
        initialPositionX = transform.position.x;
        endPositionX = endPoint.transform.position.x;
        if (unlocked != null)
        {
            unlocked.SetActive(false);
        }
        else
        {
            Debug.Log("No 'unlocked' GameObject set");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lastPosition = Input.mousePosition;
        }
        if (Input.GetMouseButton(0))
        {
            Vector3 delta = Input.mousePosition - lastPosition;
            float newX = transform.position.x - delta.x * Time.deltaTime * moveSpeed;

            if (newX >= initialPositionX && newX <= endPositionX)
            {
                transform.position = new Vector3(newX, transform.position.y, transform.position.z);
                lastPosition = Input.mousePosition;
                //Debug.Log(newX);
                if (transform.position.x >= endPositionX-0.1)
                {
                    Unlock();
                }
            }
        }
    }

    void Unlock()
    {
        if(unlocked != null)
        {
            unlocked.SetActive(true);
            Debug.Log("button unlocked!");
        }
        else
        {
            //Debug.Log("No 'unlocked' GameObject set");
        }
    }
}
