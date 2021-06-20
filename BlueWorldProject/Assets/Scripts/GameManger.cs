using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class GameManager : MonoBehaviour
{
    public static Vector2 screenBounds;

    public int initialScore = 0;

    public bool isAlive;


    private DifficultyManager difficultyManager;
    //private HealthBar healthBar;
    private TextMeshProUGUI scoreText;
    private GameObject gameOver;

    private int score;
    private int initialHealth;
    private float health;

    private int scoreMultiplier = 1;
    private int speedMultiplier = 1;
   // private LeaderboardsManager leaderboardsManager;
    private bool savedScore = false;

    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        difficultyManager = FindObjectOfType<DifficultyManager>();
        //leaderboardsManager = FindObjectOfType<LeaderboardsManager>();

        score = initialScore;
        initialHealth = difficultyManager.getInitialHealth();
        health = initialHealth;
        Debug.Log("initial health : " + health);

        isAlive = true;

        //healthBar = GameObject.Find("HealthBar").GetComponent<HealthBar>();
        scoreText = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();
        gameOver = GameObject.Find("GameOver");

       // healthBar?.SetMaxHealth(initialHealth);
        gameOver?.SetActive(false);

        //if (healthBar == null)
        //{
        //    Debug.Log("GameManager did not find a HealthBar");
        //}

        if (scoreText == null)
        {
            Debug.Log("GameManager did not find a ScoreText");
        }

        if (gameOver == null)
        {
            Debug.Log("GameManager did not find a GameOver");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateHealth(float healthChange)
    {
        health = Mathf.Min(health + healthChange, initialHealth);
       // healthBar?.SetHealth(health);

        if (health <= 0)
        {
            GameOver();
        }
    }

    public void UpdateScore(int scoreChange)
    {
        // hacky guard to fix saved score and post-save score updates
        if (savedScore)
        {
            Debug.Log("score update called post-save: " + score.ToString() + " + " + (scoreChange * scoreMultiplier).ToString());
            return;
        }
        score += scoreChange * scoreMultiplier;

        scoreText?.SetText("Score: " + score);
    }

    private void GameOver()
    {
        isAlive = false;
        gameOver?.SetActive(true);
        Time.timeScale = 0f;
       // FindObjectOfType<AudioManager>().Play("PlayerDeath");
        // Save score here!
        if (!savedScore)
        {
            Debug.Log("saving score " + score.ToString());
            //leaderboardsManager.AddHighscoreEntry(score, "LOCAL PLAYER");
            savedScore = true;
        }
    }

    public void ScoreMultiplying(bool isStarting)
    {
        if (isStarting)
        {
            scoreMultiplier += 1;
        }
        else if (scoreMultiplier > 1)
        {
            scoreMultiplier -= 1;
        }
    }

    public void SpeedMultiplying(bool isStarting)
    {
        if (isStarting)
        {
            speedMultiplier += 1;
        }
        else if (speedMultiplier > 1)
        {
            speedMultiplier -= 1;
        }
    }

    public float GetSpeedMultiplier()
    {
        return 1.0f / speedMultiplier;
    }
}
