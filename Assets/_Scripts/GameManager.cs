using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;

    public GameObject lightE;
    public GameObject mediumE;
    public GameObject heavyE;

    private float xCoord;
    private float zCoord;
    private int zone;

    private float timerF;
    private int timerInt;
    public Text timer;

    private bool alive;
    private bool spawn1;

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
    }

    // Use this for initialization
    void Start () {
        StartCoroutine(Wave1());
	}
	
	// Update is called once per frame
	void Update () {
		if(alive == true)
        {
            timerF = timerF + Time.deltaTime; //* 10;
            timerInt = Mathf.RoundToInt(timerF);
            timer.text = "Score: " + timerInt;

            if(timerInt <= 300)
            {
                spawn1 = true;
            }
        }
    }

   IEnumerator Wave1()
    {
        if(alive == true)
        {
            while (spawn1 == true)
            {
                yield return new WaitForSeconds(3f);
                zone = UnityEngine.Random.Range(1, 4);
                if (zone == 1)
                {
                    xCoord = UnityEngine.Random.Range(-500, 500);
                    Instantiate(lightE, new Vector3(xCoord, 100, 700), Quaternion.identity);
                }
                if (zone == 2)
                {
                    zCoord = UnityEngine.Random.Range(-500, 500);
                    Instantiate(lightE, new Vector3(700, 100, zCoord), Quaternion.identity);
                }
                if (zone == 3)
                {
                    xCoord = UnityEngine.Random.Range(-500, 500);
                    Instantiate(lightE, new Vector3(xCoord, 100, -700), Quaternion.identity);
                }
                if (zone == 4)
                {
                    zCoord = UnityEngine.Random.Range(-500, 500);
                    Instantiate(lightE, new Vector3(-700, 100, zCoord), Quaternion.identity);
                }
                yield return new WaitForSeconds(2f);
            }
        }
    }
}
