using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsScreenUI : MonoBehaviour
{
    public AudioMixer mainAudioMixer;
    public Slider mainVolumeSlider;

    // Start is called before the first frame update
    void Start()
    {
    OnMainVolumeChange();    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMainVolumeChange()
    {
        // start with the slider value(assuming our slider run from 0 to 1)
        float newVolume = mainVolumeSlider.value;
        if (newVolume <= 0)
        {
            newVolume = -80;
        }
        else
        {
            //We are >0, so start by finding the log10 value
            newVolume = Mathf.Log10(newVolume);
            //make it in the 0-20db range (instead of 0-1)
            newVolume = newVolume * 20;
        }

        //set the volume to the new volume setting
        mainAudioMixer.SetFloat("MainVolume", newVolume);
    }

    public void OnMusicVolumeChange()
    {
        // start with the slider value(assuming our slider run from 0 to 1)
        float newVolume = mainVolumeSlider.value;
        if (newVolume <= 0)
        {
            newVolume = -80;
        }
        else
        {
            //We are >0, so start by finding the log10 value
            newVolume = Mathf.Log10(newVolume);
            //make it in the 0-20db range (instead of 0-1)
            newVolume = newVolume * 20;
        }

        //set the volume to the new volume setting
        mainAudioMixer.SetFloat("MusicVolume", newVolume);
    }

    public void OnSFXVolumeChange()
    {
        // start with the slider value(assuming our slider run from 0 to 1)
        float newVolume = mainVolumeSlider.value;
        if (newVolume <= 0)
        {
            newVolume = -80;
        }
        else
        {
            //We are >0, so start by finding the log10 value
            newVolume = Mathf.Log10(newVolume);
            //make it in the 0-20db range (instead of 0-1)
            newVolume = newVolume * 20;
        }

        //set the volume to the new volume setting
        mainAudioMixer.SetFloat("SFXVolume", newVolume);
    }
}
