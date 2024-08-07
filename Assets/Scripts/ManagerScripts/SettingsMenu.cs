using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    //reference to audioMixer
    public AudioMixer audioMixer;

    //array for screen resolutions
    Resolution[] resolutions;

    public Dropdown resolutionDropdown;

    private void Start()
    {
        //get list of resolutions available and place into an array
        resolutions = Screen.resolutions;

        //clear default options
        resolutionDropdown.ClearOptions();

        //list of strings 
        List<string> options = new List<string>();

        //current resolution
        int currentResIndex = 0;

        //loop through each element in the array and turn the array of resolutions into a list of strings to be able to be displayed
        for (int i = 0; i < resolutions.Length; i++)
        {
            //save the string as "width" + "x" + "height"
            string option = resolutions[i].width + " x " + resolutions[i].height;
            //add the option to the list of strings
            options.Add(option);

            //if it loops over the current resolution of the monitor then set the resolution to that by default
            //cannot compare two resolution types so comapare width and height
            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResIndex = i;
            }            
        }

        //add the resolution List options. AddOption function only takes in a String
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResIndex;
        resolutionDropdown.RefreshShownValue();
    }

    //function for setting the volume
    public void SetVolume(float volume)
    {
        //set the volume of the audioMixer to the float value set with the volume slider between -80 and 0
        audioMixer.SetFloat("volume", volume);
    }

    //function for the Fullscreen toggle 
    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
}
