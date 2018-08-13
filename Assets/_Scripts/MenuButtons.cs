using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuButtons : MonoBehaviour {

    public GameObject quit;
    public GameObject mainMenu;
    public GameObject characterSelect;

    public void StartGame()
    {
        mainMenu.SetActive(false);
        characterSelect.SetActive(true);
    }

    public void Player1()
    {
        PlayerPrefs.SetInt("Player", 1);
        SceneManager.LoadScene("PlaneGame");
    }

    public void Player2()
    {
        PlayerPrefs.SetInt("Player", 2);
        SceneManager.LoadScene("PlaneGame");
    }

    public void Player3()
    {
        PlayerPrefs.SetInt("Player", 3);
        SceneManager.LoadScene("PlaneGame");
    }

    public void Back()
    {
        characterSelect.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void Controls()
    {
        SceneManager.LoadScene("Controls");
    }

    public void About()
    {
        SceneManager.LoadScene("About");
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
