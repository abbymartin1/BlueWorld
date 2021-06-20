using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonEventHandlerScript : MonoBehaviour
{
    //public Button easyButton;
    //public Button mediumButton;
    //public Button hardButton;
    public GameObject pauseMenu;
    public static bool isGamePaused = false;

    private DifficultyManager difficultyManager;
    private GameManager gameManager;

    void Start()
    {
        difficultyManager = FindObjectOfType<DifficultyManager>();
        gameManager = FindObjectOfType<GameManager>();
        //setDefaultSelectedDifficultyButton();
    }

    //private void setDefaultSelectedDifficultyButton()
    //{
    //   // switch (difficultyManager.gameLevel)
    //   // {
    //        //case GameLevel.Easy:
    //        //    easyButton?.Select();
    //        //    if (!easyButton) { Debug.Log("easyButton reference is null "); }
    //        //    break;
    //        //case GameLevel.Medium:
    //        //    mediumButton?.Select();
    //        //    if (!mediumButton) { Debug.Log("easyButton reference is null "); }
    //        //    break;
    //        //case GameLevel.Hard:
    //        //    hardButton?.Select();
    //        //    if (!hardButton) { Debug.Log("easyButton reference is null "); }
    //        //    break;
    //        //default:
    //        //    easyButton?.Select();
    //        //    if (!easyButton) { Debug.Log("easyButton reference is null in default case "); }
    //        //    break;
    //   // }
    //}

    private void playButtonSound()
    {
        //FindObjectOfType<AudioManager>().Play("ButtonClick");
    }

    public void playGame()
    {
        playButtonSound();
       // difficultyManager.userStartedGame(true);
        // load game page
        SceneManager.LoadScene(1);
    }

    public void goToSettings()
    {
        playButtonSound();
        // load settings page 
        SceneManager.LoadScene(2);
    }

    public void goToInstructions()
    {
        playButtonSound();
        // load instructions page
        SceneManager.LoadScene(3);
    }

    public void goToMainMenu()
    {
        playButtonSound();
        if (isGamePaused)
        {
            isGamePaused = false;
        }
        difficultyManager.stopIncreasingDifficulty();
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void pauseGame()
    {
        if (gameManager.isAlive)
        {
            isGamePaused = true;
            playButtonSound();
            // load pause menu UI
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void resumeGame()
    {
        isGamePaused = false;
        playButtonSound();
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void quitGame()
    {
        playButtonSound();
        Application.Quit();
    }

    public void setDifficultyToEasy()
    {
        playButtonSound();
        //difficultyManager.setGameLevel(GameLevel.Easy);
    }

    public void setDifficultyToMedium()
    {
        playButtonSound();
       // difficultyManager.setGameLevel(GameLevel.Medium);
    }

    public void setDifficultyToHard()
    {
        playButtonSound();
       // difficultyManager.setGameLevel(GameLevel.Hard);
    }
}
