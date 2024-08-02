using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    //load the level select scene
    public void LoadLevelSelect()
    {
        SceneManager.LoadSceneAsync(1);
    }
}
