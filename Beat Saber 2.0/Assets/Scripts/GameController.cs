using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    public bool gameOver;
    bool restart;
    bool canScore;

    public TextMeshPro timer;
    public TextMeshPro scoreText;
    public TextMeshPro lifeTextX;
    public GameObject restartBox;
    public GameObject gameOverText;
    public GameObject masterMusic;
    public GameObject gameOverVoice;
    public GameObject restartText;

    private int score;
    private float startTime;
    private float totalTime;
    private int life;
    private string[] x = {"X X X", "X X O", "X O O", "O O O"};

    private float t1;
    private AudioSource ambient;
    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        restart = false;
        canScore = true;
        score = 0;
        totalTime = 240;
        startTime = Time.time;
        life = 3;
        lifeTextX.text = "O O O";
        scoreText.text = "Score";
        timer.text = "00:00";
        restartBox.SetActive(false);
        gameOverText.SetActive(false);
        masterMusic.SetActive(true);
        gameOverVoice.SetActive(false);
        restartText.SetActive(false);
        ambient = GetComponent<AudioSource>();        
    }

    // Update is called once per frame
    void Update()
    {
        float t = Time.time - startTime;
        float remTime = totalTime - t;

        string minutes = ((int)remTime / 60).ToString();
        string seconds = (remTime % 60).ToString("f0");
        if (remTime % 60 < 10)
        {
            seconds = "0" + seconds;
        }

        if (remTime > 0 && gameOver == false)
        {
            timer.text = "0" + minutes + ":" + seconds;
        } else if(gameOver == false)
        {
            GameOver();
        }

        if (gameOver == true)
        {
            float t2 = Time.time - t1;
            if (t2 > 5)
            {
                restartBox.SetActive(true);
                gameOverText.SetActive(false);
                restartText.SetActive(true);
            }
        }

    }

    public void GameOver()
    {
        gameOver = true;
        restart = true;
        canScore = false;
        t1 = Time.time;
        gameOverText.SetActive(true);
        masterMusic.SetActive(false);
        gameOverVoice.SetActive(true);
        ambient.Play();
    }

    public void addScore()
    {
        if(canScore ==  true)
        {
            score = score + 1;
            scoreText.text = score.ToString();
        }        
    }

    public void reduceLife()
    {
        life = life - 1;
        //lifeText.text = life.ToString();
        lifeTextX.text = x[life];  
        if (life == 0)
        {
            GameOver();
        }
    }

    public void gameRestart()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}