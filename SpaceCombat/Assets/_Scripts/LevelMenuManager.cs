using UnityEngine;
using UnityEngine.SceneManagement;

/**
This script controls the actions for the levels menu

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

--> Loaded build index == 2
*/
public class LevelMenuManager : MonoBehaviour
{
    public void PlayLevel_0()
    {
        Debug.Log("Level Selection == 1");
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene("Gameplay00");
    }

    public void PlayLevel_1()
    {
        Debug.Log("Level Selection == 2");
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        SceneManager.LoadScene("Gameplay01");
    }

    public void PlayLevel_2()
    {
        Debug.Log("Level Selection == 3");
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
        SceneManager.LoadScene("Gameplay02");
    }

    public void PlayLevel_3()
    {
        Debug.Log("Level Selection == 4");
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 4);
        SceneManager.LoadScene("Gameplay03");
    }

    public void PlayLevel_4()
    {
        Debug.Log("Level Selection == 5");
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 5);
        SceneManager.LoadScene("Gameplay04");
    }

    public void PlayLevel_5()
    {
        Debug.Log("Level Selection == 6");
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 6);
         SceneManager.LoadScene("Gameplay05");
    }

    public void GoBack()
    {
        Debug.Log("Back Button Pressed");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }
}
