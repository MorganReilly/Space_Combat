using UnityEngine;
using UnityEngine.SceneManagement;

/**
This script controls the actions for the main menu
*/
public class MenuManager : MonoBehaviour
{
    public void StartGame()
    {
        Debug.Log("Game Started");
        // Using Scence manager to load the next scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("Game Quit");
        Application.Quit();
    }

    public void GameSettings()
    {
        Debug.Log("Settings Clicked");
        Application.Quit();
    }
}
