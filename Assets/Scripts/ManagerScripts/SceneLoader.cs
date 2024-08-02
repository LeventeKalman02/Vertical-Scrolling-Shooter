using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    //script to load all 3 levels 
    public void LoadLevel1()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void LoadLevel2()
    {
        SceneManager.LoadSceneAsync(2);
    }

    public void LoadLevel3()
    {
        SceneManager.LoadSceneAsync(3);
    }
}