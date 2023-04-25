using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveOnClick : MonoBehaviour
{
    public List<GameObject> puppies;
    public GameObject continueButton;
    // Start is called before the first frame update
    void Start()
    {
        continueButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (puppies.Count > 0)
            {
                //Debug.Log("clicked!");
                GameObject.Destroy(puppies[0]);
                puppies.RemoveAt(0);
            }
            else
            {
                continueButton.SetActive(true);
                //Debug.Log("no more puppies :(");
            }
            
        }
    }
}
