using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject hazard;
   
    public GameObject[] enemySpawns;

    public Vector2 spawnValue;
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
    private bool easyCars = true;
    private float[] spawnValues = { -3.2f, 3.2f };
    private int score;
    private int easyCarKilled =0;
    private int hardCarKilled = 0;

    public void SetCarKilled(int count)
    {
        easyCarKilled += count;
    }

    public void SetHardCarKilled(int count)
    {
        hardCarKilled += count;
    }

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
        while (easyCars)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                Vector2 spawnPosition = new Vector2(Random.Range(-spawnValue.x, spawnValue.x), spawnValue.y);
                Instantiate(hazard, spawnPosition, Quaternion.identity);
                yield return new WaitForSeconds(spawnWait);
                easyCarKilled++;
            }
            if (gameOver)
                break;

            if (easyCarKilled >= 10)
            {
                print("End spawn waves");
                activateHelp();
                easyCarKilled = 0;
                hardCount();
                easyCars = false;
                
            }
            yield return new WaitForSeconds(vaweWait);
        }
    }

    void hardCount()
    {
        print("Start Hard Count");
        while(hardCarKilled <=10)
        {
            hardCarKilled++;

        }
        print("end hard count loop");
        StartCoroutine(hardSpawnWaves());
    }

    IEnumerator hardSpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                float point = spawnValues[Random.Range(0, 2)];
                Vector2 spawnPosition = new Vector2(Random.Range(point, point*1.5f), spawnValue.y);
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

    void activateHelp()
    {
        for(int i = 0; i<enemySpawns.Length; i++)
        {
            enemySpawns[i].SetActive(true);
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
