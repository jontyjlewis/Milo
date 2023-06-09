using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TrickCheck : MonoBehaviour
{
    public List<GameObject> trick;
    public GameObject continueButton;
    public TMP_Text trickName;
    public Image baseImage;
    public Sprite newImage;
    public AudioSource sfx;

    // Start is called before the first frame update
    void Start()
    {
        continueButton.SetActive(false);
        trickName = GetComponent<TMP_Text>();
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
        trickName.text = "Good boy!";
        if(sfx != null)
            sfx.Play();
        continueButton.SetActive(true);
        baseImage.sprite = newImage;
    }
}
