using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameLevel
{
    Easy,
    Medium,
    Hard
}

public class DifficultyManager : MonoBehaviour
{
    public static DifficultyManager instance;
    public GameLevel gameLevel;

    private bool shouldIncreaseDifficulty = false;
    private float startTime = 0;
    private float difficultyMultiplierSpeed = 1;
    private float difficultyMultiplierSpawnRate = 1;

    // Variables for Easy Setting 
    private const float spawnRateEasy = 2f; // new customer every 2 seconds, up to every 1 sec
    private const int percentUnmaskedEasy = 50; // 50 percent unmasked
    private const int speedOfCharactersEasy = 5; // max speed will be 15
    private const int initialHealthEasy = 100;
    private const float powerUpSpawnRateEasy = 10.0f;

    // Variables for Medium Setting 
    private const float spawnRateMedium = 1.5f; // new customer every 1.5 seconds, up to every 0.75 sec 
    private const int percentUnmaskedMedium = 55; // 55 percent unmasked
    private const int speedOfCharactersMedium = 6; // max speed will be 18
    private const int initialHealthMedium = 90;
    private const float powerUpSpawnRateMedium = 20.0f;

    // Variables for Hard Setting 
    private const float spawnRateHard = 1f; // new customer every 1 seconds, up to every 0.5 sec
    private const int percentUnmaskedHard = 60; // 60 percent unmasked
    private const int speedOfCharactersHard = 7; //max speed will be 21
    private const int initialHealthHard = 80;
    const float powerUpSpawnRateHard = 30.0f;

    // Initialization
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        gameLevel = GameLevel.Easy;
    }

    // Update is called once per frame
    void Update()
    {
        // every 10 seconds increase the difficulty multipliers
        if (((Time.time - startTime) > 10) && shouldIncreaseDifficulty)
        {
            startTime = Time.time;
            // increase the speed of customers by 0.1 every 10 seconds (capped at 3)
            difficultyMultiplierSpeed = Mathf.Min(difficultyMultiplierSpeed + 0.1f, 3f);
            print("difficulty multiplier speed: " + difficultyMultiplierSpeed);
            // increase the spawn rate by 0.05 (capped at 2)
            difficultyMultiplierSpawnRate = Mathf.Min(difficultyMultiplierSpeed + 0.05f, 2f);
            print("difficulty multiplier spawn rare: " + difficultyMultiplierSpawnRate);
        }
    }

    public void setGameLevel(GameLevel level)
    {
        // called from Settings Page
        gameLevel = level;
    }

    public int getPercentUnMaskedCustomers()
    {
        print("game level test in unMaskedCustomers " + gameLevel);
        switch (gameLevel)
        {
            case GameLevel.Easy:
                return percentUnmaskedEasy;
            case GameLevel.Medium:
                return percentUnmaskedMedium;
            case GameLevel.Hard:
                return percentUnmaskedHard;
            default:
                return 50;
        }
    }

    public float getSpawnRate()
    {
        switch (gameLevel)
        {
            case GameLevel.Easy:
                return spawnRateEasy / difficultyMultiplierSpawnRate;
            case GameLevel.Medium:
                return spawnRateMedium / difficultyMultiplierSpawnRate;
            case GameLevel.Hard:
                return spawnRateHard / difficultyMultiplierSpawnRate;
            default:
                return 1f;
        }
    }

    public float getSpeedOfCustomers()
    {
        switch (gameLevel)
        {
            case GameLevel.Easy:
                return speedOfCharactersEasy * difficultyMultiplierSpeed;
            case GameLevel.Medium:
                return speedOfCharactersMedium * difficultyMultiplierSpeed;
            case GameLevel.Hard:
                return speedOfCharactersHard * difficultyMultiplierSpeed;
            default:
                return 6f;
        }
    }

    public int getInitialHealth()
    {
        switch (gameLevel)
        {
            case GameLevel.Easy:
                return initialHealthEasy;
            case GameLevel.Medium:
                return initialHealthMedium;
            case GameLevel.Hard:
                return initialHealthHard;
            default:
                return 100;
        }
    }

    public void userStartedGame(bool userStartedGame)
    {
        // called once user presses start button from main menu screen 
        shouldIncreaseDifficulty = userStartedGame;
        startTime = Time.time;
        // reset difficulty variables in case user was playing a previous game
        difficultyMultiplierSpawnRate = 1;
        difficultyMultiplierSpeed = 1;
    }

    public void stopIncreasingDifficulty()
    {
        shouldIncreaseDifficulty = false;
    }
    public float getPowerUpSpawnRate()
    {
        switch (gameLevel)
        {
            case GameLevel.Easy:
                return powerUpSpawnRateEasy;
            case GameLevel.Medium:
                return powerUpSpawnRateMedium;
            case GameLevel.Hard:
                return powerUpSpawnRateHard;
            default:
                return powerUpSpawnRateEasy;
        }
    }
}

