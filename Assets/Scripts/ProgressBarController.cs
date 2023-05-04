using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ProgressBarController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Image fillImage;
    [SerializeField] private float decreaseSpeed = 0.5f;

    private bool isButtonPressed = false;

    public GameObject continueButton;
    void Start()
    {
        continueButton.SetActive(false);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isButtonPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isButtonPressed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isButtonPressed)
        {
            if (fillImage.fillAmount <= 0f)
            {
                Debug.Log("Bar Empty!");
                continueButton.SetActive(true);
            }
            else
            {
                fillImage.fillAmount -= decreaseSpeed * Time.deltaTime;
            }
        }
    }

    //private void OnButtonPressed()
    //{
    //    isButtonPressed = true;
    //}
    //private void OnButtonReleased()
    //{
    //    isButtonPressed = false;
    //}
}
