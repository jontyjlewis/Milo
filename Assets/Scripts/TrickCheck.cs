using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrickCheck : MonoBehaviour
{
    public List<GameObject> trick;
    public GameObject continueButton;
    // Start is called before the first frame update
    void Start()
    {
        continueButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void checkComplete()
    {
        for(int i = 0; i < trick.Count; i++)
        {
            if(trick[i].GetComponent<DropPoint>().isCorrect != true)
            {
                Debug.Log("Trick not complete");
                return;
            }
        }
        Debug.Log("should see this on all correct");
        continueButton.SetActive(true);
    }
}
