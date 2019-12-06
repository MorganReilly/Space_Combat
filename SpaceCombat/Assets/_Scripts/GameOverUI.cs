using UnityEngine;
using UnityEngine.SceneManagement;

/* Adapted from:  https://youtu.be/bSG5m0Q6W4c */
public class GameOverUI : MonoBehaviour
{
    public void Quit()
    {
        Debug.Log("APPLICATION QUIT!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -1);
    }

    public void Retry()
    {
        Application.LoadLevel(Application.loadedLevel);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
