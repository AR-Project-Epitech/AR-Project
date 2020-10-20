using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    void Start()
    {
      //  FindObjectOfType<AudioManager>().Play("Minecraft theme");
    }

    public void PlayGame () {
        FindObjectOfType<AudioManager>().Play("Click1");

       // Debug.Log("Stop Minecraft & start Undertale music");

        FindObjectOfType<AudioManager>().Stop("Minecraft theme");
        FindObjectOfType<AudioManager>().Play("Undertale theme");
      //  Debug.Log("PLAY GAME");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame() {
        FindObjectOfType<AudioManager>().Play("Click2");
        Debug.Log("QUIT GAME");
        Application.Quit();
    }

}