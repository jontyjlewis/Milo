using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextEffects : MonoBehaviour
{
    private TMP_Text textComponent;
    private float startSize;

    public void Start()
    {
        textComponent = GetComponent<TMP_Text>();
        startSize = textComponent.fontSize;
    }
    public void StartHoverTextButton()
    {
        textComponent.fontSize = startSize * 1.2f;
    }
    public void EndHoverTextButton()
    {
        textComponent.fontSize = startSize;
    }
}
