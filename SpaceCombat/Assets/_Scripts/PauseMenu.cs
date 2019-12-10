using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/** Adapted from: https://youtu.be/JivuXdrIHK0 */

public class PauseMenu : MonoBehaviour
{
    // use for checking if game is paused
    public static bool gameIsPaused = false;

    // Reference to game object
    public GameObject puaseMenuUI;

    // Update is called once per frame
    void Update()
    {
        // Using escape as a way of pausing the game
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Game is already paused => Resume
            if (gameIsPaused)
            {
                ResumeGame();
            }
            // Game is not paused => Pause game
            else
            {
                PauseGame();
            }
        }
    }

    public void ResumeGame()
    {
        // Need to do the same as pause menu but the opposite
        puaseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    void PauseGame()
    {
        puaseMenuUI.SetActive(true);
        // Need to freeze time
        // Set this by changing the speed of time passing => Set to 0
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void MainMenu()
    {
        Debug.Log("Main Menu pressed");
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game");
        Application.Quit();
    }
}
