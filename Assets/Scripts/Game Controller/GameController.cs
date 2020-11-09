using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject hazard;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    private int score;
    public Text scoreText;

    public Text gameOverText;
    private bool gameOver;
    public Button restartButton;
    private bool restart;
    public Button backToMenuButton;
    private bool backToMenu;

    void Start()
    {
        restart = false;
        restartButton.gameObject.SetActive(false);
        gameOver = false;
        gameOverText.gameObject.SetActive(false);
        backToMenu = false;
        backToMenuButton.gameObject.SetActive(false);
        score = 0;
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

            if (gameOver)
            {
                restartButton.gameObject.SetActive(true);
                restart = true;
                backToMenuButton.gameObject.SetActive(true);
                backToMenu = true;
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
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        gameOver = true;
    }
}
