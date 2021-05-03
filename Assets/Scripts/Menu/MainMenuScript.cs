using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public void NextLevel(int sceneNumber)
    {
        PlayerSelect.playerNumber = 1;
        SceneManager.LoadScene(sceneNumber);
    }

    public void NextLevel1(int sceneNumber)
    {
        PlayerSelect.playerNumber = 2;
        SceneManager.LoadScene(sceneNumber);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
