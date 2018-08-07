using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {

    public static PlayerMovement instance = null;

    //private Rigidbody _rb;

    public float speed;

    public Camera pCam;
    public GameObject bullet; public GameObject bullet2;
    public GameObject rocket; public GameObject rocket2;
    public GameObject laser; public GameObject laser2;

    private Quaternion qrotation;

    public int health;
    public Image hpBar;
    public int damage;

    public Slider bulletHeat;
    public Image heatBar;
    private bool canShoot;
    private int fireRate;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

	// Use this for initialization
	void Start () {
        health = 30;
        damage = 1;
	}
	
	// Update is called once per frame
	void Update () {

        hpBar.fillAmount = 0.034f * health;

        if(GameManager.instance.paused == false || GameManager.instance.alive == false)
        {
            qrotation = this.transform.rotation;

                transform.position += pCam.transform.up * speed;
            if (Input.GetKey(KeyCode.A))
            {
                this.transform.eulerAngles += new Vector3(0, -3f, 0);
            }
            if (Input.GetKey(KeyCode.D))
            {
                this.transform.eulerAngles += new Vector3(0, 3f, 0);
            }
            #region Damage
            if(canShoot == true && fireRate <= 0)
            {
                if (Input.GetKey(KeyCode.Space) && damage == 1)
                {
                    Instantiate(bullet, this.transform.position, qrotation);
                    bulletHeat.value += 0.02f;
                    fireRate = 10;
                }
                if (Input.GetKey(KeyCode.Space) && damage == 2)
                {
                    Instantiate(bullet2, this.transform.position, qrotation);
                    bulletHeat.value += 0.01f;
                    fireRate = 5;
                }
                if (Input.GetKey(KeyCode.Space) && damage == 3)
                {
                    Instantiate(rocket, this.transform.position, qrotation);
                    bulletHeat.value += 0.01f;
                    fireRate = 5;
                }
                if (Input.GetKey(KeyCode.Space) && damage == 4)
                {
                    Instantiate(rocket2, this.transform.position, qrotation);
                    bulletHeat.value += 0.01f;
                    fireRate = 5;
                }
                if (Input.GetKey(KeyCode.Space) && damage == 5)
                {
                    Instantiate(laser, this.transform.position, qrotation);
                    bulletHeat.value += 0.01f;
                    fireRate = 5;
                }
                if (Input.GetKey(KeyCode.Space) && damage == 6)
                {
                    Instantiate(laser2, this.transform.position, qrotation);
                    bulletHeat.value += 0.01f;
                    fireRate = 5;
                }
                if (!Input.GetKey(KeyCode.Space))
                {
                    bulletHeat.value -= 0.003f;
                }
            }
            if (bulletHeat.value == 1)
            {
                canShoot = false;
                heatBar.color = Color.red;
            }
            if(canShoot == false)
            {
                bulletHeat.value -= 0.002f;
            }
            if (bulletHeat.value == 0 && canShoot == false)
            {
                canShoot = true;
                heatBar.color = Color.white;
            }
            if(fireRate > 0)
            {
                fireRate--;
            }
            #endregion
        }

        if(health <= 0)
        {
            GameManager.instance.GameOver();
        }
    }
}
