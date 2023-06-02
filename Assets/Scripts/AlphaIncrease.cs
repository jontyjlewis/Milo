using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlphaIncrease : MonoBehaviour
{
    public Image targetImage;
    public float fadeDuration = 1f;
    public float delay = 1f;
    public float transitionDelay = 2f;

    public GameObject currentScene;
    public GameObject nextScene;

    public LevelChanger levelChanger;
    
    private IEnumerator Start()
    {
        yield return new WaitForSeconds(delay);
        yield return StartCoroutine(IncreaseAlpha());
        yield return new WaitForSeconds(transitionDelay);

        // calls this once delay is finished
        levelChanger.ActFade(currentScene, nextScene);
    }

    private IEnumerator IncreaseAlpha()
    {
        Color imageColor = targetImage.color;
        float elapsedTime = 0f;
        float startAlpha = imageColor.a;
        float targetAlpha = 1f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float normalizedTime = elapsedTime / fadeDuration;
            imageColor.a = Mathf.Lerp(startAlpha, targetAlpha, normalizedTime);
            targetImage.color = imageColor;
            yield return null;
        }

        // Ensure the final alpha value is set correctly
        imageColor.a = targetAlpha;
        targetImage.color = imageColor;
    }
}
