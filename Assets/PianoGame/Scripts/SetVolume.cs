using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SetVolume : MonoBehaviour
{
    public AudioMixer mixer1;
    public Slider slider1;

    void Start()
    {
        slider1.value = PlayerPrefs.GetFloat("MusicVolume", 0.5f);
    }
    public void SetLevel(float sliderValue)
    {
        mixer1.SetFloat("MusicVol", Mathf.Log10(sliderValue) * 30);
        PlayerPrefs.SetFloat("MusicVolume", sliderValue);
    }
}
