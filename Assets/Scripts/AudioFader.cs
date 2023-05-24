using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AudioFader
{
    // To run add the following to desired script
    // StartCoroutine(AudioFader.FadeOut(audioMusicHere, timeAsFloat.f));
    public static IEnumerator FadeOut(AudioSource audioSource, float FadeTime)
    {
        float startVolume = audioSource.volume;

        while (audioSource.volume > 0)
        {
            audioSource.volume -= startVolume * Time.deltaTime / FadeTime;
            yield return null;
        }

        audioSource.Stop();
        audioSource.volume = startVolume;
    }

    // To run add the following to desired script
    // StartCoroutine(AudioFader.FadeIn(audioMusicHere, timeAsFloat.f));
    public static IEnumerator FadeIn(AudioSource audioSource, float FadeTime)
    {
        float startVolume = 0.2f;

        audioSource.volume = 0;
        audioSource.Play();

        while (audioSource.volume < 1.0f)
        {
            audioSource.volume += startVolume * Time.deltaTime / FadeTime;
            yield return null;
        }
        audioSource.volume = 1f;
    }
}
