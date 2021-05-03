using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject hazard;
    public GameObject Player1;
    public GameObject Player2;
   
    public GameObject[] enemySpawns;
    public GameObject BossSpawn;

    public Vector2 spawnValue;
    public int hazardCount;
    public int kilLimit;
    public float spawnWait;
    public float startWait;
    public float vaweWait;

    public Text RestartText;
    public Text scoreText;
    public Text gameOverText;
    public Text armorText;
    public Text doubleText;

    private int player;
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

    private void Awake()
    {
        player = PlayerSelect.playerNumber;
        if(player == 1)
        {
            Player1.SetActive(true);
        }
        else if(player == 2)
        {
            Player1.SetActive(true);
            Player2.SetActive(true);
        }
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
        gameOverText.gameObject.SetActive(true);
        RestartText.gameObject.SetActive(true);
        restart = true;
        gameOver = true;


        Player1.GetComponent<PlayerController>().speed = 0;
        Player2.GetComponent<PlayerController>().speed = 0;
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

            if (easyCarKilled >= kilLimit)
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
                hardCarKilled++;
               
            }
            if (gameOver)
                break;
            if(hardCarKilled >= 50)
            {
                ActivateBoss();
                yield return new WaitForSeconds(vaweWait);
                BossSpawn.SetActive(false);
            }
            yield return new WaitForSeconds(vaweWait);
        }

    }

    void ActivateBoss()
    {
        for (int i = 0; i < enemySpawns.Length; i++)
        {
            enemySpawns[i].SetActive(false);
        }

        BossSpawn.SetActive(true);
    }


    private void Update()
    {
        if(restart)
        {
            if(Input.GetKeyDown(KeyCode.R))
            {

                SceneManager.LoadScene(1);
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
