using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    //variable to be able to check if the game is currently paused
    //can be used in other scripts to check if the game is paused using PauseMenu.isPaused
    public static bool isPaused = false;

    public GameObject pauseMenuUI;

    // Update is called once per frame
    private void Update()
    {
        //if the Escape key is pressed then pause the game
        //else resume
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else{
                Pause();
            }
        }
    }

    //unfreeze time
    //hide pause menu
    //set variable to false
    public void Resume()
    {
        //hide the display
        pauseMenuUI.SetActive(false);
        //unpause the game
        Time.timeScale = 1f;
        //set variable to false
        isPaused = false;
    }

    //Freeze Time in the game
    //display pause menu
    //set variable to true
    public void Pause()
    {
        //show the display
        pauseMenuUI.SetActive(true);
        //pause the game
        Time.timeScale = 0f;
        //set variable to true
        isPaused = true;
    }

    //Load the main menu scene
    public void LoadMenu()
    {
        //Debug.Log("Loading Menu");
        SceneManager.LoadScene(0);
        //set the game time back to 1
        Time.timeScale = 1f;
        //set the variable back to false
        isPaused = false;
    }

    //Quit the Game
    public void QuitGame()
    {
        Debug.Log("Quitting Game");
        Application.Quit();
    }
}
