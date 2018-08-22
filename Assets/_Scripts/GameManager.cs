using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;

    private int pl1 = 1;
    public GameObject player1;
    private int pl2 = 2;
    public GameObject player2;
    private int pl3 = 3;
    public GameObject player3;

    public bool paused;
    public GameObject pauseMenu;

    public Image playerHP;

    public GameObject lightE; public GameObject lightE2; 
    public GameObject mediumE; public GameObject mediumE2;
    public GameObject heavyE; public GameObject heavyE2;

    private float xCoord;
    private float zCoord;
    private int zone;

    public Text timerText;
    public GameObject outOfBounds;

    public float timerF;
    public float enemySpeed;
    public int speedPoints;
    public int timerInt;
    public Text timer;
    public int score;

    public bool alive;
    public GameObject gameOver;

    private bool spawn1;
    private bool spawn2;
    private bool spawn3;
    private bool spawn4;
    private bool spawn5;

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
        spawn5 = false;
        score = 0;

        paused = false;
    }

    // Use this for initialization
    void Start () {
        if(pl1 == PlayerPrefs.GetInt("Player"))
        {
            Instantiate(player1, new Vector3(0, 100, 0), Quaternion.identity);
        }
        if(pl2 == PlayerPrefs.GetInt("Player"))
        {
            Instantiate(player2, new Vector3(0, 100, 0), Quaternion.identity);
        }
        if (pl3 == PlayerPrefs.GetInt("Player"))
        {
            Instantiate(player3, new Vector3(0, 100, 0), Quaternion.identity);
        }
        StartCoroutine(Wave1());
	}
	
	// Update is called once per frame
	void Update () {

		if(alive == true)
        {
            timerF = timerF + Time.deltaTime * 10;
            enemySpeed = enemySpeed + Time.deltaTime;
            timerInt = Mathf.RoundToInt(timerF) + score;
            timer.text = "Score: " + timerInt;

            playerHP.fillAmount = PlayerMovement.instance.health / PlayerMovement.instance.maxHealth;

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                paused = !paused;
            }

            if(enemySpeed >= 10)
            {
                speedPoints += 10;
                enemySpeed = 0;
            }

            if(paused == true)
            {
                pauseMenu.SetActive(true);
            }
            if(paused == false)
            {
                pauseMenu.SetActive(false);
            }
            if(paused == true || alive == false)
            {
                Time.timeScale = 0;
            }
            if(paused == false && alive == true)
            {
                Time.timeScale = 1;
            }

            if (PlayerMovement.instance.heatBar.fillAmount <= 0.01 && PlayerMovement.instance.canShoot == true)
            {
                PlayerMovement.instance.canShoot = false;
                PlayerMovement.instance.heatBar.color = Color.red;
            }
            if (PlayerMovement.instance.heatBar.fillAmount >= 1 && PlayerMovement.instance.canShoot == false)
            {
                PlayerMovement.instance.canShoot = true;
                PlayerMovement.instance.heatBar.color = Color.yellow;
            }
            if (PlayerMovement.instance.canShoot == false && !Input.GetKey(KeyCode.S))
            {
                PlayerMovement.instance.heatBar.fillAmount += 0.002f;
            }
            #region Wave Timer
            if (timerF <= 200)
            {
                spawn1 = true;
            }
            if(timerF >= 201 && timerF <= 400)
            {
                spawn1 = false;
                spawn2 = true;
            }
            if(timerF >= 401 && timerF <= 600)
            {
                spawn1 = false;
                spawn2 = false;
                spawn3 = true;
            }
            if(timerF >= 601 && timerF <= 800)
            {
                spawn1 = false;
                spawn2 = false;
                spawn3 = false;
                spawn4 = true;
            }
            if(timerF >= 801)
            {
                spawn1 = false;
                spawn2 = false;
                spawn3 = false;
                spawn4 = false;
                spawn5 = true;
            }
            #endregion
        }
    }

    IEnumerator Wave1()
    {
        if (alive == true)
        {
            while (spawn1 == true)
            {
                yield return new WaitForSeconds(1f);
                zone = UnityEngine.Random.Range(1, 4);
                if (zone == 1)
                {
                    xCoord = UnityEngine.Random.Range(-500, 500);
                    Instantiate(lightE, new Vector3(xCoord, 100, 1050), Quaternion.identity);
                }
                if (zone == 2)
                {
                    zCoord = UnityEngine.Random.Range(-500, 500);
                    Instantiate(lightE2, new Vector3(1050, 100, zCoord), Quaternion.identity);
                }
                if (zone == 3)
                {
                    xCoord = UnityEngine.Random.Range(-500, 500);
                    Instantiate(lightE, new Vector3(xCoord, 100, -1050), Quaternion.identity);
                }
                if (zone == 4)
                {
                    zCoord = UnityEngine.Random.Range(-500, 500);
                    Instantiate(lightE2, new Vector3(-1050, 100, zCoord), Quaternion.identity);
                }
                yield return new WaitForSeconds(1f);
            }
            while (spawn2 == true)
            {
                yield return new WaitForSeconds(2f);
                zone = UnityEngine.Random.Range(1, 4);
                if (zone == 1)
                {
                    xCoord = UnityEngine.Random.Range(-500, 500);
                    Instantiate(lightE, new Vector3(xCoord, 100, 1050), Quaternion.identity);
                    xCoord = UnityEngine.Random.Range(-500, 500);
                    Instantiate(lightE2, new Vector3(xCoord, 100, 1050), Quaternion.identity);
                    xCoord = UnityEngine.Random.Range(-500, 500);
                    Instantiate(lightE, new Vector3(xCoord, 100, 1050), Quaternion.identity);
                }
                if (zone == 2)
                {
                    zCoord = UnityEngine.Random.Range(-500, 500);
                    Instantiate(lightE, new Vector3(1050, 100, zCoord), Quaternion.identity);
                    zCoord = UnityEngine.Random.Range(-500, 500);
                    Instantiate(lightE2, new Vector3(1050, 100, zCoord), Quaternion.identity);
                    zCoord = UnityEngine.Random.Range(-500, 500);
                    Instantiate(lightE2, new Vector3(1050, 100, zCoord), Quaternion.identity);
                }
                if (zone == 3)
                {
                    xCoord = UnityEngine.Random.Range(-500, 500);
                    Instantiate(lightE, new Vector3(xCoord, 100, -1050), Quaternion.identity);
                    xCoord = UnityEngine.Random.Range(-500, 500);
                    Instantiate(lightE2, new Vector3(xCoord, 100, -1050), Quaternion.identity);
                    xCoord = UnityEngine.Random.Range(-500, 500);
                    Instantiate(lightE, new Vector3(xCoord, 100, -1050), Quaternion.identity);
                }
                if (zone == 4)
                {
                    zCoord = UnityEngine.Random.Range(-500, 500);
                    Instantiate(lightE, new Vector3(-1050, 100, zCoord), Quaternion.identity);
                    zCoord = UnityEngine.Random.Range(-500, 500);
                    Instantiate(lightE2, new Vector3(-1050, 100, zCoord), Quaternion.identity);
                    zCoord = UnityEngine.Random.Range(-500, 500);
                    Instantiate(lightE2, new Vector3(-1050, 100, zCoord), Quaternion.identity);
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
                    Instantiate(mediumE, new Vector3(xCoord, 100, 1050), Quaternion.identity);
                    xCoord = UnityEngine.Random.Range(-500, 500);
                    Instantiate(lightE, new Vector3(xCoord, 100, 1050), Quaternion.identity);
                    xCoord = UnityEngine.Random.Range(-500, 500);
                    Instantiate(lightE2, new Vector3(xCoord, 100, 1050), Quaternion.identity);
                    xCoord = UnityEngine.Random.Range(-500, 500);
                    Instantiate(lightE, new Vector3(xCoord, 100, 1050), Quaternion.identity);
                }
                if (zone == 2)
                {
                    zCoord = UnityEngine.Random.Range(-500, 500);
                    Instantiate(lightE, new Vector3(1050, 100, zCoord), Quaternion.identity);
                    zCoord = UnityEngine.Random.Range(-500, 500);
                    Instantiate(lightE2, new Vector3(1050, 100, zCoord), Quaternion.identity);
                    zCoord = UnityEngine.Random.Range(-500, 500);
                    Instantiate(lightE, new Vector3(1050, 100, zCoord), Quaternion.identity);
                    zCoord = UnityEngine.Random.Range(-500, 500);
                    Instantiate(lightE2, new Vector3(1050, 100, zCoord), Quaternion.identity);
                    zCoord = UnityEngine.Random.Range(-500, 500);
                    Instantiate(lightE2, new Vector3(1050, 100, zCoord), Quaternion.identity);
                }
                if (zone == 3)
                {
                    xCoord = UnityEngine.Random.Range(-500, 500);
                    Instantiate(mediumE2, new Vector3(xCoord, 100, -1050), Quaternion.identity);
                    xCoord = UnityEngine.Random.Range(-500, 500);
                    Instantiate(lightE, new Vector3(xCoord, 100, -1050), Quaternion.identity);
                    xCoord = UnityEngine.Random.Range(-500, 500);
                    Instantiate(lightE2, new Vector3(xCoord, 100, -1050), Quaternion.identity);
                    xCoord = UnityEngine.Random.Range(-500, 500);
                    Instantiate(lightE, new Vector3(xCoord, 100, -1050), Quaternion.identity);
                }
                if (zone == 4)
                {
                    zCoord = UnityEngine.Random.Range(-500, 500);
                    Instantiate(lightE, new Vector3(-1050, 100, zCoord), Quaternion.identity);
                    zCoord = UnityEngine.Random.Range(-500, 500);
                    Instantiate(lightE2, new Vector3(-1050, 100, zCoord), Quaternion.identity);
                    zCoord = UnityEngine.Random.Range(-500, 500);
                    Instantiate(lightE, new Vector3(-1050, 100, zCoord), Quaternion.identity);
                    zCoord = UnityEngine.Random.Range(-500, 500);
                    Instantiate(lightE2, new Vector3(-1050, 100, zCoord), Quaternion.identity);
                    zCoord = UnityEngine.Random.Range(-500, 500);
                    Instantiate(lightE2, new Vector3(-1050, 100, zCoord), Quaternion.identity);
                }
                yield return new WaitForSeconds(3f);
            }
            while (spawn4 == true)
            {
                yield return new WaitForSeconds(5f);
                zone = UnityEngine.Random.Range(1, 4);
                if (zone == 1)
                {
                    xCoord = UnityEngine.Random.Range(-500, 500);
                    Instantiate(mediumE, new Vector3(xCoord, 100, 1050), Quaternion.identity);
                    xCoord = UnityEngine.Random.Range(-500, 500);
                    Instantiate(mediumE2, new Vector3(xCoord, 100, 1050), Quaternion.identity);
                    xCoord = UnityEngine.Random.Range(-500, 500);
                    Instantiate(mediumE, new Vector3(xCoord, 100, 1050), Quaternion.identity);
                    xCoord = UnityEngine.Random.Range(-500, 500);
                    Instantiate(lightE, new Vector3(xCoord, 100, 1050), Quaternion.identity);
                    xCoord = UnityEngine.Random.Range(-500, 500);
                    Instantiate(lightE2, new Vector3(xCoord, 100, 1050), Quaternion.identity);
                    xCoord = UnityEngine.Random.Range(-500, 500);
                    Instantiate(lightE, new Vector3(xCoord, 100, 1050), Quaternion.identity);
                }
                if (zone == 2)
                {
                    zCoord = UnityEngine.Random.Range(-500, 500);
                    Instantiate(heavyE, new Vector3(1050, 100, zCoord), Quaternion.identity);
                    zCoord = UnityEngine.Random.Range(-500, 500);
                    Instantiate(lightE, new Vector3(1050, 100, zCoord), Quaternion.identity);
                    zCoord = UnityEngine.Random.Range(-500, 500);
                    Instantiate(lightE2, new Vector3(1050, 100, zCoord), Quaternion.identity);
                    zCoord = UnityEngine.Random.Range(-500, 500);
                    Instantiate(lightE, new Vector3(1050, 100, zCoord), Quaternion.identity);
                    zCoord = UnityEngine.Random.Range(-500, 500);
                    Instantiate(lightE2, new Vector3(1050, 100, zCoord), Quaternion.identity);
                    zCoord = UnityEngine.Random.Range(-500, 500);
                    Instantiate(lightE2, new Vector3(1050, 100, zCoord), Quaternion.identity);
                }
                if (zone == 3)
                {
                    xCoord = UnityEngine.Random.Range(-500, 500);
                    Instantiate(mediumE, new Vector3(xCoord, 100, -1050), Quaternion.identity);
                    xCoord = UnityEngine.Random.Range(-500, 500);
                    Instantiate(mediumE2, new Vector3(xCoord, 100, -1050), Quaternion.identity);
                    xCoord = UnityEngine.Random.Range(-500, 500);
                    Instantiate(mediumE2, new Vector3(xCoord, 100, -1050), Quaternion.identity);
                    xCoord = UnityEngine.Random.Range(-500, 500);
                    Instantiate(lightE, new Vector3(xCoord, 100, -1050), Quaternion.identity);
                    xCoord = UnityEngine.Random.Range(-500, 500);
                    Instantiate(lightE2, new Vector3(xCoord, 100, -1050), Quaternion.identity);
                    xCoord = UnityEngine.Random.Range(-500, 500);
                    Instantiate(lightE, new Vector3(xCoord, 100, -1050), Quaternion.identity);
                }
                if (zone == 4)
                {
                    zCoord = UnityEngine.Random.Range(-500, 500);
                    Instantiate(mediumE, new Vector3(-1050, 100, zCoord), Quaternion.identity);
                    zCoord = UnityEngine.Random.Range(-500, 500);
                    Instantiate(mediumE2, new Vector3(-1050, 100, zCoord), Quaternion.identity);
                    zCoord = UnityEngine.Random.Range(-500, 500);
                    Instantiate(lightE, new Vector3(-1050, 100, zCoord), Quaternion.identity);
                    zCoord = UnityEngine.Random.Range(-500, 500);
                    Instantiate(lightE2, new Vector3(-1050, 100, zCoord), Quaternion.identity);
                    zCoord = UnityEngine.Random.Range(-500, 500);
                    Instantiate(lightE, new Vector3(-1050, 100, zCoord), Quaternion.identity);
                    zCoord = UnityEngine.Random.Range(-500, 500);
                    Instantiate(lightE2, new Vector3(-1050, 100, zCoord), Quaternion.identity);
                    zCoord = UnityEngine.Random.Range(-500, 500);
                    Instantiate(lightE2, new Vector3(-1050, 100, zCoord), Quaternion.identity);
                }
                yield return new WaitForSeconds(2f);
            }
            while (spawn5 == true)
            {
                yield return new WaitForSeconds(4f);
                zone = UnityEngine.Random.Range(1, 4);
                if (zone == 1)
                {
                    xCoord = UnityEngine.Random.Range(-500, 500);
                    Instantiate(heavyE, new Vector3(xCoord, 100, 1050), Quaternion.identity);
                    xCoord = UnityEngine.Random.Range(-500, 500);
                    xCoord = UnityEngine.Random.Range(-500, 500);
                    Instantiate(mediumE, new Vector3(xCoord, 100, 1050), Quaternion.identity);
                    xCoord = UnityEngine.Random.Range(-500, 500);
                    Instantiate(mediumE2, new Vector3(xCoord, 100, 1050), Quaternion.identity);
                    xCoord = UnityEngine.Random.Range(-500, 500);
                    Instantiate(mediumE, new Vector3(xCoord, 100, 1050), Quaternion.identity);
                    xCoord = UnityEngine.Random.Range(-500, 500);
                    Instantiate(lightE, new Vector3(xCoord, 100, 1050), Quaternion.identity);
                    xCoord = UnityEngine.Random.Range(-500, 500);
                    Instantiate(lightE2, new Vector3(xCoord, 100, 1050), Quaternion.identity);
                    xCoord = UnityEngine.Random.Range(-500, 500);
                    Instantiate(lightE, new Vector3(xCoord, 100, 1050), Quaternion.identity);
                    Instantiate(mediumE2, new Vector3(xCoord, 100, 1050), Quaternion.identity);
                }
                if (zone == 2)
                {
                    zCoord = UnityEngine.Random.Range(-500, 500);
                    Instantiate(heavyE, new Vector3(1050, 100, zCoord), Quaternion.identity);
                    zCoord = UnityEngine.Random.Range(-500, 500);
                    Instantiate(heavyE2, new Vector3(1050, 100, zCoord), Quaternion.identity);
                    zCoord = UnityEngine.Random.Range(-500, 500);
                    Instantiate(heavyE, new Vector3(1050, 100, zCoord), Quaternion.identity);
                    zCoord = UnityEngine.Random.Range(-500, 500);
                    Instantiate(lightE, new Vector3(1050, 100, zCoord), Quaternion.identity);
                    zCoord = UnityEngine.Random.Range(-500, 500);
                    Instantiate(lightE2, new Vector3(1050, 100, zCoord), Quaternion.identity);
                    zCoord = UnityEngine.Random.Range(-500, 500);
                    Instantiate(lightE, new Vector3(1050, 100, zCoord), Quaternion.identity);
                    zCoord = UnityEngine.Random.Range(-500, 500);
                    Instantiate(lightE2, new Vector3(1050, 100, zCoord), Quaternion.identity);
                    zCoord = UnityEngine.Random.Range(-500, 500);
                    Instantiate(lightE2, new Vector3(1050, 100, zCoord), Quaternion.identity);
                }
                if (zone == 3)
                {
                    xCoord = UnityEngine.Random.Range(-500, 500);
                    Instantiate(heavyE, new Vector3(xCoord, 100, -1050), Quaternion.identity);
                    xCoord = UnityEngine.Random.Range(-500, 500);
                    Instantiate(mediumE2, new Vector3(xCoord, 100, -1050), Quaternion.identity);
                    xCoord = UnityEngine.Random.Range(-500, 500);
                    Instantiate(mediumE, new Vector3(xCoord, 100, -1050), Quaternion.identity);
                    xCoord = UnityEngine.Random.Range(-500, 500);
                    Instantiate(mediumE2, new Vector3(xCoord, 100, -1050), Quaternion.identity);
                    xCoord = UnityEngine.Random.Range(-500, 500);
                    Instantiate(mediumE2, new Vector3(xCoord, 100, -1050), Quaternion.identity);
                    xCoord = UnityEngine.Random.Range(-500, 500);
                    Instantiate(lightE, new Vector3(xCoord, 100, -1050), Quaternion.identity);
                    xCoord = UnityEngine.Random.Range(-500, 500);
                    Instantiate(lightE2, new Vector3(xCoord, 100, -1050), Quaternion.identity);
                    xCoord = UnityEngine.Random.Range(-500, 500);
                    Instantiate(lightE, new Vector3(xCoord, 100, -1050), Quaternion.identity);
                }
                if (zone == 4)
                {
                    zCoord = UnityEngine.Random.Range(-500, 500);
                    Instantiate(heavyE, new Vector3(-1050, 100, zCoord), Quaternion.identity);
                    zCoord = UnityEngine.Random.Range(-500, 500);
                    Instantiate(heavyE2, new Vector3(-1050, 100, zCoord), Quaternion.identity);
                    zCoord = UnityEngine.Random.Range(-500, 500);
                    Instantiate(mediumE, new Vector3(-1050, 100, zCoord), Quaternion.identity);
                    zCoord = UnityEngine.Random.Range(-500, 500);
                    Instantiate(mediumE2, new Vector3(-1050, 100, zCoord), Quaternion.identity);
                    zCoord = UnityEngine.Random.Range(-500, 500);
                    Instantiate(lightE, new Vector3(-1050, 100, zCoord), Quaternion.identity);
                    zCoord = UnityEngine.Random.Range(-500, 500);
                    Instantiate(lightE2, new Vector3(-1050, 100, zCoord), Quaternion.identity);
                    zCoord = UnityEngine.Random.Range(-500, 500);
                    Instantiate(lightE, new Vector3(-1050, 100, zCoord), Quaternion.identity);
                    zCoord = UnityEngine.Random.Range(-500, 500);
                    Instantiate(lightE2, new Vector3(-1050, 100, zCoord), Quaternion.identity);
                    zCoord = UnityEngine.Random.Range(-500, 500);
                    Instantiate(lightE2, new Vector3(-1050, 100, zCoord), Quaternion.identity);
                }
                yield return new WaitForSeconds(2f);
            }
        }
    }

    public void GameOver()
    {
        alive = false;
        gameOver.SetActive(true);
        if(timerInt > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", timerInt);
        }
    }
}
