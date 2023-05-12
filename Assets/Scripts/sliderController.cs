using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sliderController : MonoBehaviour
{
    [SerializeField] GameObject slider;
    public float moveSpeed = 300f;
    public float minValue = -300f;
    public float maxValue = 300f;

    private float currVal;
    private float targetVal;

    // for scoring zone
    [SerializeField] GameObject scorezone;
    public float scorezoneMin = -150f;
    public float scorezoneMax = 150f;
    public float scorezoneSize = 150f;
    public float minDistanceMoved = 100f;

    [SerializeField] GameObject critzone;
    private float critzoneSize = 25f;

    [SerializeField] private int score = 0;
    [SerializeField] GameObject continueButton;

    public Image baseImage;
    public Sprite newImage;

    private Vector3 placeholder;

    // Start is called before the first frame update
    void Start()
    {
        currVal = minValue;
        targetVal = maxValue;
        placeholder = slider.transform.localPosition;
        randomizeScorePosition();

        critzoneSize = critzone.GetComponent<RectTransform>().sizeDelta.x;
        scorezoneSize = scorezone.GetComponent<RectTransform>().sizeDelta.x;

        continueButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(targetVal == maxValue)
        {
            currVal = Mathf.MoveTowards(currVal, maxValue, moveSpeed * Time.deltaTime);

            if(currVal >= maxValue)
            {
                targetVal = minValue;
            }
        }
        else
        {
            currVal = Mathf.MoveTowards(currVal, minValue, moveSpeed * Time.deltaTime);

            if (currVal <= minValue)
            {
                targetVal = maxValue;
            }
        }

        placeholder.x = currVal;
        slider.transform.localPosition = placeholder;
    }

    public void buttonPressed()
    {
        // check slider position against target range
        if(slider.transform.localPosition.x >= (scorezone.transform.localPosition.x - (scorezoneSize/2)) && 
            slider.transform.localPosition.x <= (scorezone.transform.localPosition.x + (scorezoneSize / 2)))
        {
            if(slider.transform.localPosition.x >= (scorezone.transform.localPosition.x - (critzoneSize / 2)) &&
            slider.transform.localPosition.x <= (scorezone.transform.localPosition.x + (critzoneSize / 2)))
            {
                //Debug.Log("CRIT!!");
                moveSpeed *= 1.2f;
                score += 2;
            }
            else
            {
                //Debug.Log("Still hit, just bad");
                moveSpeed *= 1.1f;
                score += 1;
            }
            
            if(score >= 5)
            {
                moveSpeed = 0f;
                continueButton.SetActive(true);
                baseImage.sprite = newImage;
            }
            else
            {
                randomizeScorePosition();
            }
        }
    }

    private void randomizeScorePosition()
    {
        // randomizes the scoring zome position within bounds
        Vector3 temp = scorezone.transform.localPosition;
        temp.x = Random.Range(scorezoneMin, scorezoneMax);
        while (Mathf.Abs(temp.x - scorezone.transform.localPosition.x) < 50)
        {
            temp.x = Random.Range(scorezoneMin, scorezoneMax);
        }
        scorezone.transform.localPosition = temp;
    }
}
