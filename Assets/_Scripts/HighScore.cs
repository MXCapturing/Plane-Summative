using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour {

    public static HighScore instance = null;
    private static bool created = false;

    public int highScore1P;
    public Text highScore1;
    public InputField hs1Input;
    public Text highScore1Input;
    public Text highScore1Name;

    public int highScore2P;
    public Text highScore2;
    public InputField hs2Input;
    public Text highScore2Input;
    public Text highScore2Name;

    public int highScore3P;
    public Text highScore3;
    public InputField hs3Input;
    public Text highScore3Input;
    public Text highScore3Name;

    public int highScore4P;
    public Text highScore4;
    public InputField hs4Input;
    public Text highScore4Input;
    public Text highScore4Name;

    public int highScore5P;
    public Text highScore5;
    public InputField hs5Input;
    public Text highScore5Input;
    public Text highScore5Name;

    public int points;
    public Text currentPoints;

    public GameObject menuButton;


    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        if (!created)
        {
            DontDestroyOnLoad(this.gameObject);
            created = true;
        }
    }

    public void NewScore()
    {
        currentPoints.text = "Points: " + points;
        if (points > highScore1P)
        {
            menuButton.SetActive(false);
            points = highScore1P;
            highScore1Name.enabled = false;
            hs1Input.enabled = true;

            if (Input.GetKeyDown(KeyCode.Return))
            {
                highScore1Input = highScore1Name;
                hs1Input.enabled = false;
                highScore1Name.enabled = true;
                menuButton.SetActive(true);
            }
        }
        if (points <= highScore1P && points > highScore2P)
        {
            menuButton.SetActive(false);
            points = highScore2P;
            highScore2Name.enabled = false;
            hs2Input.enabled = true;

            if (Input.GetKeyDown(KeyCode.Return))
            {
                highScore2Input = highScore2Name;
                hs2Input.enabled = false;
                highScore2Name.enabled = true;
                menuButton.SetActive(true);
            }
        }
        if (points <= highScore2P && points > highScore3P)
        {
            menuButton.SetActive(false);
            points = highScore3P;
            highScore3Name.enabled = false;
            hs3Input.enabled = true;

            if (Input.GetKeyDown(KeyCode.Return))
            {
                highScore3Input = highScore3Name;
                hs3Input.enabled = false;
                highScore3Name.enabled = true;
                menuButton.SetActive(true);
            }
        }
        if (points <= highScore3P && points > highScore4P)
        {
            menuButton.SetActive(false);
            points = highScore4P;
            highScore4Name.enabled = false;
            hs4Input.enabled = true;

            if (Input.GetKeyDown(KeyCode.Return))
            {
                highScore4Input = highScore4Name;
                hs4Input.enabled = false;
                highScore4Name.enabled = true;
                menuButton.SetActive(true);
            }
        }
        if (points <= highScore4P && points > highScore5P)
        {
            menuButton.SetActive(false);
            points = highScore5P;
            highScore5Name.enabled = false;
            hs5Input.enabled = true;

            if (Input.GetKeyDown(KeyCode.Return))
            {
                highScore5Input = highScore5Name;
                hs5Input.enabled = false;
                highScore5Name.enabled = true;
                menuButton.SetActive(true);
            }
        }
    }
}
