using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseScript : MonoBehaviour {

    public int health;
    public Image hpBar1;
    public Image hpBar2;

	// Use this for initialization
	void Start () {
        health = 50;
        //hpBar = this.GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
        hpBar1.fillAmount = 0.02f * health;
        hpBar2.fillAmount = 0.02f * health;

        if(health == 0)
        {

        }
	}
}
