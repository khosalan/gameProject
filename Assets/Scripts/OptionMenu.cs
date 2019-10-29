using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionMenu : MonoBehaviour
{
    public AudioMixer backgroundAudioMixer;
    public AudioMixer soundEffectAudioMixer;
    public Slider volumeSlider;

    public GameObject fullScreenOffSlider;
    public GameObject fullScreenOnSlider;    

    public Dropdown resolutionDropdown;
    Resolution[] resolutions;
    

    void Start()
    {
        if (!Screen.fullScreen)
        {
            fullScreenOffSlider.SetActive(true);
            fullScreenOnSlider.SetActive(false);
        }
        else
        {
            fullScreenOffSlider.SetActive(false);
            fullScreenOnSlider.SetActive(true);
        }
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;

        for(int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if(resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
                //Debug.Log(currentResolutionIndex);
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
        
    }

    public void SetVolume(float volume)
    {
        backgroundAudioMixer.SetFloat("volume", volume);
    }

    public void MuteOn()
    {
        backgroundAudioMixer.SetFloat("volume", -80);
    }

    public void MuteOff()
    {
        backgroundAudioMixer.SetFloat("volume", volumeSlider.value);
    }

    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        Debug.Log(resolutionIndex);
    }

    public void SoundEffectOn()
    {
        soundEffectAudioMixer.SetFloat("Volume", 10);
    }

    public void SoundEffectOff()
    {
        soundEffectAudioMixer.SetFloat("Volume", -80);
    }
}
