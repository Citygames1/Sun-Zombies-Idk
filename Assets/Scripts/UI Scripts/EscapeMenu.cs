using UnityEngine;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;

public class EscapeMenu : MonoBehaviour
{
    public TMP_Dropdown resolutionDropdown;
    private AudioManager audioManager;
    [SerializeField] private AudioManager.SoundType sound;
    Resolution[] resolutions;

    void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();

        resolutions = Screen.resolutions;

        //clear the options
        resolutionDropdown.ClearOptions();

        //create a new list of options
        List<string> options = new List<string>();

        int currentResolutionIndex = 0;

        //take each resolution from screen.resolutions individually and add them to the options list
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        
        //add them to the dropdown
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetFullScreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void SetVolumeLevel(GameObject thisSlider)
    {
        float currentVolumeLevel = thisSlider.GetComponent<Slider>().value;
        audioManager.currentVolumeLevel = currentVolumeLevel;
    }

    public void PlaySound(AudioManager.Sound soundType)
    {
        AudioManager.Instance.Play(sound);
    }
}
