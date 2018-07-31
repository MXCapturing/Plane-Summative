using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuButtons : MonoBehaviour {

    public GameObject quit;
    public GameObject mainMenu;

    public void StartGame()
    {
        SceneManager.LoadScene("");
    }

    public void Controls()
    {
        SceneManager.LoadScene("");
    }

    public void About()
    {
        SceneManager.LoadScene("");
    }

    public void QuitConfirm()
    {
        quit.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void QuitDeny()
    {
        mainMenu.SetActive(true);
        quit.SetActive(false);
    }
}
