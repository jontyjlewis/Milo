using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class OptionsController : MonoBehaviour
{
    public AudioMixerGroup masterVol;
    public AudioMixerGroup musicVol;
    public AudioMixerGroup SFXVol;

    public void adjustMasterVolume(float input)
    {
        masterVol.audioMixer.SetFloat("masterVol", -80 +  (input * 8) );
    }

    public void adjustMusicVolume(float input)
    {
        masterVol.audioMixer.SetFloat("musicVol", -80 + (input * 8));
    }

    public void adjustSFXVolume(float input)
    {
        masterVol.audioMixer.SetFloat("SFXVol", -80 + (input * 8));
    }
}
