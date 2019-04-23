using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public Mover asteroid1Speed;
    public Mover asteroid2Speed;
    public Mover asteroid3Speed;
    public BGScroller backgroundSpeed;
    public GameObject[] hazards;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    public Text restartText;
    public Text hardText;
    public Text gameOverText;
    public Text scoreText;
    public Text winText;
    public Text timeText;
    public AudioClip victory;
    public AudioClip lose;
    public AudioSource musicSource;
    public bool winCondition;
    private int score;
    private float timeLeft = 30;
    private bool gameOver;
    private bool restart;
    private bool alreadyPlayed;
    private bool timeAttack;
    private bool startTime;

    void Start()
    {
        gameOver = false;
        restart = false;
        startTime = false;
        alreadyPlayed = false;
        winCondition = false;
        restartText.text = "";
        hardText.text = "";
        gameOverText.text = "";
        winText.text = "";
        timeText.text = "";
        hardText.text = "Press 'Left Shift' for Hard Mode";
        score = 0;
        UpdateScore();
        StartCoroutine (SpawnWaves());
        asteroid1Speed.speed = -5;
        asteroid2Speed.speed = -5;
        asteroid3Speed.speed = -5;
    }

    void Update()
    {
        if (restart)
        {
            if (Input.GetKeyDown (KeyCode.Space))
            {
                SceneManager.LoadScene("Final Project");
            }
        }
        if (startTime)
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                gameOver = false;
                restart = false;
                timeAttack = true;
                alreadyPlayed = false;
                winCondition = false;
                restartText.text = "";
                gameOverText.text = "";
                winText.text = "";
                score = 0;
                timeLeft = 30;
                UpdateScore();
                StartCoroutine(SpawnWaves());
            }
        }
        if (timeAttack)
        {
            startTime = false;
            timeText.text = ("Time: " + timeLeft.ToString("f0"));
            timeLeft -= Time.deltaTime;
            if (timeLeft <= 0)
            {
                timeLeft = 0;
                TimerEnded();
                timeAttack = false;
            }
        }
    }

    void FixedUpdate()
    {
        if (Input.GetKey("escape"))
            Application.Quit();
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            asteroid1Speed.speed = -10;
            asteroid2Speed.speed = -10;
            asteroid3Speed.speed = -10;
            hardText.text = "Hard Mode Engaged";
        }
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
            if (gameOver)
            {
                restartText.text = "Press 'Space' for Restart";
                timeText.text = "Press 'T' for Time Attack Mode";
                restart = true;
                startTime = true;
                break;
            }
        }
    }
  
    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "Points: " + score;
        if (!timeAttack)
        {
            if (score >= 100)
            {
                winCondition = true;
                winText.text = "You win!";
                gameOverText.text = "Game created by Paul Abbruzzese";
                if (!alreadyPlayed)
                {
                    musicSource.PlayOneShot(victory);
                    alreadyPlayed = true;
                }
                gameOver = true;
                restart = true;
            }
        }
    }

    void TimerEnded()
    {
        winCondition = true;
        winText.text = "You win!";
        gameOverText.text = "Game created by Paul Abbruzzese";
        if (!alreadyPlayed)
        {
            musicSource.PlayOneShot(victory);
            alreadyPlayed = true;
        }
        gameOver = true;
        restart = true;
    }

    public void GameOver()
    {
        gameOverText.text = "Game Over!";
        musicSource.PlayOneShot(lose);
        alreadyPlayed = true;
        gameOver = true;
        if (timeAttack)
        {
            timeAttack = false;
        }
    }
}