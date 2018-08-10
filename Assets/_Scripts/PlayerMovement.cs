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

    public float health;
    public int damage;

    public bool canShoot;
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

        if(health > 30)
        {
            health = 30;
        }

        if(GameManager.instance.paused == false && GameManager.instance.alive == true)
        {
            qrotation = this.transform.rotation;

            health -= 0.01f;

            transform.position += pCam.transform.up * speed;
            if(transform.position.z > 800)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, -800);
            }
            if (transform.position.z < -800)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, 800);
            }
            if (transform.position.x > 800)
            {
                transform.position = new Vector3(-800, transform.position.y, transform.position.z);
            }
            if (transform.position.x < -800)
            {
                transform.position = new Vector3(800, transform.position.y, transform.position.z);
            }
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
                    GameManager.instance.heatGauge.value += 0.02f;
                    fireRate = 10;
                }
                if (Input.GetKey(KeyCode.Space) && damage == 2)
                {
                    Instantiate(bullet2, this.transform.position, qrotation);
                    GameManager.instance.heatGauge.value += 0.01f;
                    fireRate = 5;
                }
                if (Input.GetKey(KeyCode.Space) && damage == 3)
                {
                    Instantiate(rocket, this.transform.position, qrotation);
                    GameManager.instance.heatGauge.value += 0.01f;
                    fireRate = 5;
                }
                if (Input.GetKey(KeyCode.Space) && damage == 4)
                {
                    Instantiate(rocket2, this.transform.position, qrotation);
                    GameManager.instance.heatGauge.value += 0.01f;
                    fireRate = 5;
                }
                if (Input.GetKey(KeyCode.Space) && damage == 5)
                {
                    Instantiate(laser, this.transform.position, qrotation);
                    GameManager.instance.heatGauge.value += 0.01f;
                    fireRate = 5;
                }
                if (Input.GetKey(KeyCode.Space) && damage >= 6)
                {
                    Instantiate(laser2, this.transform.position, qrotation);
                    GameManager.instance.heatGauge.value += 0.01f;
                    fireRate = 5;
                }
                if (!Input.GetKey(KeyCode.Space) && !Input.GetKeyDown(KeyCode.LeftControl))
                {
                    GameManager.instance.heatGauge.value -= 0.003f;
                }
            }
            if(canShoot == true && Input.GetKey(KeyCode.LeftControl))
            {
                speed = 5;
                GameManager.instance.heatGauge.value += 0.01f;
            }
            if(canShoot == false || Input.GetKeyUp(KeyCode.LeftControl))
            {
                speed = 2;
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
