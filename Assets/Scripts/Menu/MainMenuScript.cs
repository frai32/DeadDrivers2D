using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public void NextLevel(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
