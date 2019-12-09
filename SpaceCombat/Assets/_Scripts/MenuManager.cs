using UnityEngine;
using UnityEngine.SceneManagement;

/**
This script controls the actions for the main menu

Current build index list:

0 -- Main Menu
1 -- Settings Menu
2 -- Levels Menu
3 -- Lvl 1
4 -- Lvl 2
5 -- Lvl 3
6 -- Lvl 4
7 -- Lvl 5
8 -- Lvl 6

--> Loaded build index == 0
*/
public class MenuManager : MonoBehaviour
{
    public void GameSettings()
    {
        // Should load build index 1
        Debug.Log("Settings Clicked");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Application.Quit();
    }

    public void SelectLevel()
    {
        // Should load build index 2
        Debug.Log("Level Selection");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    public void StartGame()
    {
        // Should load build index 3
        Debug.Log("Game Started");
        // Starting the game will just load level 1
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
    }

    public void GoBack()
    {
        Debug.Log("Back Button Pressed");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void QuitGame()
    {
        // Exit the game
        Debug.Log("Game Quit");
        Application.Quit();
    }
}
