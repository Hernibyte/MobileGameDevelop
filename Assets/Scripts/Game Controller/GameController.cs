using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public LogPlugin logger;
    public GameObject hazard;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    private const int gameTime = 60;

    private int score;
    public Text scoreText;

    private bool scoreFull;
    public Text scoreTextFull;

    public Text gameOverText;
    private bool gameOver;
    public Button restartButton;
    private bool restart;
    public Button backToMenuButton;
    private bool backToMenu;

    public Image stickFond;
    public Joystick stick;

    public Button clickButton;

    public Text timeText;
    private int timeReverse;
    private float timeTimetime;

    private float timerTime;

    void Start()
    {
        if (logger != null)
        {
            Debug.Log("genere el archivo");
            //logger.generateFile();
        }

        restart = false;
        restartButton.gameObject.SetActive(false);
        gameOver = false;
        gameOverText.gameObject.SetActive(false);
        backToMenu = false;
        backToMenuButton.gameObject.SetActive(false);
        scoreFull = false;
        scoreTextFull.gameObject.SetActive(false);
        score = 0;
        stickFond.gameObject.SetActive(true);
        stick.gameObject.SetActive(true);
        clickButton.gameObject.SetActive(true);
        timeText.gameObject.SetActive(true);
        timeReverse = gameTime;

        UpdateScore();
        StartCoroutine(SpawnWaves());
    }

    public void UpdateScene()
    {
        SceneManager.LoadScene("Game");
    }

    public void UpdateMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    private void Update()
    {
        timerTime += Time.deltaTime;
        timeTimetime += Time.deltaTime;

        if (timeTimetime >= 1.0f)
        {
            timeTimetime = 0.0f;

            if (timeReverse > 0) timeReverse--;
            else timeReverse = 0;
        }
        
        timeText.text = "time: " + timeReverse;
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(spawnValues.x, spawnValues.x + 1000), spawnValues.y, spawnValues.z);
                Instantiate(hazard, spawnPosition, Quaternion.identity);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            if (gameOver || timerTime >= gameTime)
            {
                restartButton.gameObject.SetActive(true);
                restart = true;
                backToMenuButton.gameObject.SetActive(true);
                backToMenu = true;
                scoreTextFull.gameObject.SetActive(true);
                scoreFull = true;
                stickFond.gameObject.SetActive(false);
                stick.gameObject.SetActive(false);
                clickButton.gameObject.SetActive(false);
                timeText.gameObject.SetActive(false);


                if (logger != null)
                {
                    Debug.Log("mande el score");
                    //logger.sendLog(score);
                }

                break;
            }
        }
    }

    public void AddScore(int value)
    {
        score += value;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
        scoreTextFull.text = "Score: " + score;
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        gameOver = true;
    }
}