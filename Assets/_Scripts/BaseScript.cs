using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseScript : MonoBehaviour {

    public static BaseScript instance = null;

    public int health;
    //public Image hpBar1;
    public Image hpBar2;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    // Use this for initialization
    void Start () {
        health = 100;
        //hpBar = this.GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
        hpBar2.fillAmount = 0.01f * health;
       //hpBar1.fillAmount = 0.02f * health;

        if (health == 0)
        {
            GameManager.instance.GameOver();
        }
	}
}
