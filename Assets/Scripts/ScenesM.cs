using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesM : MonoBehaviour
{

    public void LoadSceneMain()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void LoadSceneGame()
    {
        SceneManager.LoadScene("ColorSwitch");
    }
}
