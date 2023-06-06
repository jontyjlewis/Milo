using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ImageEffects : MonoBehaviour
{
    public void HoverImageStart()
    {
        transform.localScale = new Vector3(1.2f, 1.2f, 1);
    }

    public void HoverImageEnd()
    {
        transform.localScale = new Vector3(1f, 1f, 1);
    }
}
