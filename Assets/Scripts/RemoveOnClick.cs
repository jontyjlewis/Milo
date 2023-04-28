using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RemoveOnClick : MonoBehaviour
{
    public List<GameObject> puppies;
    public List<Sprite> expressions;
    public Image milo;
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
            if (puppies.Count > 0 && puppies.Count < 4)
            {
                expressions.RemoveAt(0);
                milo.sprite = expressions[0];
            }
        }
    }
}
