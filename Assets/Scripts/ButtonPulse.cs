using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonPulse : MonoBehaviour
{
    public Button button;
    public float delay = 5f;
    public float pulseDuration = 1f;
    public float pulseScale = 1.2f;

    private Coroutine pulseCoroutine;

    private void Start()
    {
        StartCoroutine(StartPulseAfterDelay());
    }

    private IEnumerator StartPulseAfterDelay()
    {
        // waits a set delay time before pulsing 
        yield return new WaitForSeconds(delay);
        pulseCoroutine = StartCoroutine(PulseButton());
    }

    private IEnumerator PulseButton()
    {
        while (true)
        {
            yield return PulseToScale(pulseScale, pulseDuration);
            yield return PulseToScale(1f, pulseDuration);
        }
    }

    private IEnumerator PulseToScale(float targetScale, float duration)
    {
        Vector3 originalScale = button.transform.localScale;
        float time = 0f;

        while (time < duration)
        {
            float scale = Mathf.Lerp(originalScale.x, targetScale, time / duration);
            button.transform.localScale = new Vector3(scale, scale, 1f);

            time += Time.deltaTime;
            yield return null;
        }

        button.transform.localScale = new Vector3(targetScale, targetScale, 1f);
    }

    public void StopPulse()
    {
        StopCoroutine(pulseCoroutine);
        button.transform.localScale = new Vector3(1f, 1f, 1f);
    }
}
