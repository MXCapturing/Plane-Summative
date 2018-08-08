using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public void Resume()
    {
        GameManager.instance.paused = false;
    }

    public void Restart()
    {
        SceneManager.LoadScene("PlaneGame");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
