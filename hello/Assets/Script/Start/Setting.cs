using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class Setting : MonoBehaviour
{
    public AudioMixer audioVolume;
    public static float volumeBar;
    public Slider sliderBar;
    public void SetVolume(float volume)
    {
        audioVolume.SetFloat("volume", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("volume", volume);
    }

    public void GetVolume()
    {
        volumeBar = PlayerPrefs.GetFloat("volume");
        sliderBar.value = volumeBar;
    }

}
