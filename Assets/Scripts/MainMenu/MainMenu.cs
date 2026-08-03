using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public string mapName = "Map1";
    Resolution[] resolutions;
    public TMP_Dropdown resolutionDropdown;
    private AudioManager audioManager;
    [SerializeField] private AudioManager.SoundType sound;

    public GameObject StartMenu;
    public GameObject SettingsMenu;
    public GameObject MapChoiceMenu;
    public GameObject MapSettingsMenu;

    public void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();

        ActivateStartScreen();

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

    public void quitApplication()
    {
        Application.Quit();
    }

    public void setMapName(string newMapName)
    {
        mapName = newMapName;
    }

    public void changeScene()
    {
        SceneManager.LoadScene(mapName);
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

    public void PlaySound()
    {
        AudioManager.Instance.Play(sound);
    }

    //Main menu swaps
    public void ActivateStartScreen()
    {
        StartMenu.transform.position = new Vector2(0,0);
        SettingsMenu.transform.position = new Vector2(-25,0);
        MapChoiceMenu.transform.position = new Vector2(0,15);
        MapSettingsMenu.transform.position = new Vector2(25,0);
    }
    public void ActivateSettingsScreen()
    {
        StartMenu.transform.position = new Vector2(0,-15);
        SettingsMenu.transform.position = new Vector2(0,0);
        MapChoiceMenu.transform.position = new Vector2(0,15);
        MapSettingsMenu.transform.position = new Vector2(25,0);
    }
    public void ActivateMapChoiceScreen()
    {
        StartMenu.transform.position = new Vector2(0,-15);
        SettingsMenu.transform.position = new Vector2(-25,0);
        MapChoiceMenu.transform.position = new Vector2(0,0);
        MapSettingsMenu.transform.position = new Vector2(25,0);
    }
    public void ActivateMapSettingsScreen()
    {
        StartMenu.transform.position = new Vector2(0,-15);
        SettingsMenu.transform.position = new Vector2(-25,0);
        MapChoiceMenu.transform.position = new Vector2(0,15);
        MapSettingsMenu.transform.position = new Vector2(0,0);
    }
}
