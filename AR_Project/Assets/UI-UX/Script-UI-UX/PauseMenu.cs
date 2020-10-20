using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject PauseMenuUI;
    public GameObject PauseBtnUI;


    public void PauseGame() {
        FindObjectOfType<AudioManager>().Play("Click1");
        FindObjectOfType<AudioManager>().Pause("Undertale theme");
        FindObjectOfType<AudioManager>().Play("Minecraft theme");
        PauseMenuUI.SetActive(true);
        PauseBtnUI.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    public void ResumeGame() {
        FindObjectOfType<AudioManager>().Play("Click2");
        FindObjectOfType<AudioManager>().Pause("Minecraft theme");
        FindObjectOfType<AudioManager>().Play("Undertale theme");
        PauseMenuUI.SetActive(false);
        PauseBtnUI.SetActive(true);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void RestartGame()
    {
        FindObjectOfType<AudioManager>().Play("Click1");
        FindObjectOfType<AudioManager>().Stop("Minecraft theme");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
        GameStats.setArrows(GameStats.nbArrowsMax);
        GameStats.setScore(0);
    }

    public void QuitGame()
    {
        FindObjectOfType<AudioManager>().Play("Click2");
        Debug.Log("QUIT GAME");
        Application.Quit();
    }
}
