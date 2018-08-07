using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;

    public bool paused;
    public GameObject pauseMenu;

    public GameObject lightE; public GameObject lightE2; 
    public GameObject mediumE; public GameObject mediumE2;
    public GameObject heavyE; public GameObject heavyE2;

    private float xCoord;
    private float zCoord;
    private int zone;

    public float timerF;
    public int timerInt;
    public Text timer;
    public int score;

    public bool alive;
    public GameObject gameOver;

    private bool spawn1;
    private bool spawn2;
    private bool spawn3;
    private bool spawn4;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        SetUp();
    }

    private void SetUp()
    {
        alive = true;
        spawn1 = true;
        spawn2 = false;
        spawn3 = false;
        spawn4 = false;
        score = 0;

        paused = false;
    }

    // Use this for initialization
    void Start () {
        StartCoroutine(Wave1());
	}
	
	// Update is called once per frame
	void Update () {
		if(alive == true)
        {
            timerF = timerF + Time.deltaTime * 10;
            timerInt = Mathf.RoundToInt(timerF) + score;
            timer.text = "Score: " + timerInt;

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                paused = !paused;
            }

            if(paused == true)
            {
                pauseMenu.SetActive(true);
                Time.timeScale = 0;
            }
            if(paused == false)
            {
                pauseMenu.SetActive(false);
                Time.timeScale = 1;
            }
            #region Wave Timer
            if (timerF <= 300)
            {
                spawn1 = true;
            }
            if(timerF >= 301 && timerF <= 600)
            {
                spawn1 = false;
                spawn2 = true;
            }
            if(timerF >= 601 && timerF <= 900)
            {
                spawn2 = false;
                spawn3 = true;
            }
            if(timerF >= 901 && timerF <= 1200)
            {
                spawn3 = false;
                spawn4 = true;
            }
            #endregion
        }
    }

   IEnumerator Wave1()
    {
        if(alive == true)
        {
            while (spawn1 == true)
            {
                yield return new WaitForSeconds(5f);
                zone = UnityEngine.Random.Range(1, 4);
                if (zone == 1)
                {
                    xCoord = UnityEngine.Random.Range(-500, 500);
                    Instantiate(lightE, new Vector3(xCoord, 100, 700), Quaternion.identity);
                }
                if (zone == 2)
                {
                    zCoord = UnityEngine.Random.Range(-500, 500);
                    Instantiate(lightE2, new Vector3(700, 100, zCoord), Quaternion.identity);
                }
                if (zone == 3)
                {
                    xCoord = UnityEngine.Random.Range(-500, 500);
                    Instantiate(lightE, new Vector3(xCoord, 100, -700), Quaternion.identity);
                }
                if (zone == 4)
                {
                    zCoord = UnityEngine.Random.Range(-500, 500);
                    Instantiate(lightE2, new Vector3(-700, 100, zCoord), Quaternion.identity);
                }
                yield return new WaitForSeconds(3f);
            }
            while (spawn2 == true)
            {
                yield return new WaitForSeconds(2f);
                zone = UnityEngine.Random.Range(1, 4);
                if (zone == 1)
                {
                    xCoord = UnityEngine.Random.Range(-500, 500);
                    Instantiate(lightE, new Vector3(xCoord, 100, 700), Quaternion.identity);
                    xCoord = UnityEngine.Random.Range(-500, 500);
                    Instantiate(lightE2, new Vector3(xCoord, 100, 700), Quaternion.identity);
                }
                if (zone == 2)
                {
                    zCoord = UnityEngine.Random.Range(-500, 500);
                    Instantiate(lightE, new Vector3(700, 100, zCoord), Quaternion.identity);
                    zCoord = UnityEngine.Random.Range(-500, 500);
                    Instantiate(lightE2, new Vector3(700, 100, zCoord), Quaternion.identity);
                }
                if (zone == 3)
                {
                    xCoord = UnityEngine.Random.Range(-500, 500);
                    Instantiate(lightE, new Vector3(xCoord, 100, -700), Quaternion.identity);
                    xCoord = UnityEngine.Random.Range(-500, 500);
                    Instantiate(lightE2, new Vector3(xCoord, 100, -700), Quaternion.identity);
                }
                if (zone == 4)
                {
                    zCoord = UnityEngine.Random.Range(-500, 500);
                    Instantiate(lightE, new Vector3(-700, 100, zCoord), Quaternion.identity);
                    zCoord = UnityEngine.Random.Range(-500, 500);
                    Instantiate(lightE2, new Vector3(-700, 100, zCoord), Quaternion.identity);
                }
                yield return new WaitForSeconds(2f);
            }
            while (spawn3 == true)
            {
                yield return new WaitForSeconds(3f);
                zone = UnityEngine.Random.Range(1, 4);
                if (zone == 1)
                {
                    xCoord = UnityEngine.Random.Range(-500, 500);
                    Instantiate(mediumE, new Vector3(xCoord, 100, 700), Quaternion.identity);
                }
                if (zone == 2)
                {
                    zCoord = UnityEngine.Random.Range(-500, 500);
                    Instantiate(lightE, new Vector3(700, 100, zCoord), Quaternion.identity);
                    zCoord = UnityEngine.Random.Range(-500, 500);
                    Instantiate(lightE2, new Vector3(700, 100, zCoord), Quaternion.identity);
                }
                if (zone == 3)
                {
                    xCoord = UnityEngine.Random.Range(-500, 500);
                    Instantiate(mediumE2, new Vector3(xCoord, 100, -700), Quaternion.identity);
                }
                if (zone == 4)
                {
                    zCoord = UnityEngine.Random.Range(-500, 500);
                    Instantiate(lightE, new Vector3(-700, 100, zCoord), Quaternion.identity);
                    zCoord = UnityEngine.Random.Range(-500, 500);
                    Instantiate(lightE2, new Vector3(-700, 100, zCoord), Quaternion.identity);
                }
                yield return new WaitForSeconds(2f);
            }
            while (spawn4 == true)
            {
                yield return new WaitForSeconds(2f);
                zone = UnityEngine.Random.Range(1, 4);
                if (zone == 1)
                {
                    xCoord = UnityEngine.Random.Range(-500, 500);
                    Instantiate(mediumE, new Vector3(xCoord, 100, 700), Quaternion.identity);
                    xCoord = UnityEngine.Random.Range(-500, 500);
                    Instantiate(mediumE2, new Vector3(xCoord, 100, 700), Quaternion.identity);
                }
                if (zone == 2)
                {
                    zCoord = UnityEngine.Random.Range(-500, 500);
                    Instantiate(heavyE, new Vector3(700, 100, zCoord), Quaternion.identity);
                }
                if (zone == 3)
                {
                    xCoord = UnityEngine.Random.Range(-500, 500);
                    Instantiate(mediumE, new Vector3(xCoord, 100, -700), Quaternion.identity);
                    xCoord = UnityEngine.Random.Range(-500, 500);
                    Instantiate(mediumE2, new Vector3(xCoord, 100, -700), Quaternion.identity);
                }
                if (zone == 4)
                {
                    zCoord = UnityEngine.Random.Range(-500, 500);
                    Instantiate(mediumE, new Vector3(-700, 100, zCoord), Quaternion.identity);
                    zCoord = UnityEngine.Random.Range(-500, 500);
                    Instantiate(mediumE2, new Vector3(-700, 100, zCoord), Quaternion.identity);
                }
                yield return new WaitForSeconds(3f);
            }
        }
    }

    public void GameOver()
    {
        alive = false;
        HighScore.instance.points = timerInt;
        gameOver.SetActive(true);

        HighScore.instance.NewScore();

    }
}
