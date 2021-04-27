using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject hazard;
    public Vector2 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float vaweWait;

    public Text RestartText;
    public Text scoreText;
    public Text gameOverText;
    public Text armorText;
    public Text doubleText;

    private bool gameOver;
    private bool restart;

    private int score;

    private void Start()
    {
        gameOver = false;
        restart = false;
        
        gameOverText.text = "";
        score = 0;
        updateScore();
        StartCoroutine( spawnWaves());
    }

    public void GameOver()
    {
        gameOverText.text = "Game Over!";
        RestartText.gameObject.SetActive(true);
        restart = true;
        gameOver = true;
    }

    IEnumerator spawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                Vector2 spawnPosition = new Vector2(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y);
                
                Instantiate(hazard, spawnPosition, Quaternion.identity);
                yield return new WaitForSeconds(spawnWait);
                
            }
            
           
            if (gameOver)
                break;
            
            yield return new WaitForSeconds(vaweWait);
        }
    }

    private void Update()
    {
        if(restart)
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                
                Application.LoadLevel(Application.loadedLevel);
            }
        }

    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        updateScore();
    }

    void updateScore()
    {
        scoreText.text = "Score: " + score;
    }
}
