using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScript : MonoBehaviour
{
    //Quit the application if user presses the button
    public void ExitGame()
    {
        Debug.Log("Exiting Game");
        Application.Quit();
    }
}
