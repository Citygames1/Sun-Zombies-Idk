using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    Resolution[] resolutions;

    public TMP_Dropdown resolutionDropdown;

    public void Start()
    {
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

    public void changeScene()
    {
        SceneManager.LoadScene("Statione Immortuorum");
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
}
