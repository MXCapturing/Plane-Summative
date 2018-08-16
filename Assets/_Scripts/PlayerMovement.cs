using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {

    public static PlayerMovement instance = null;

    //private Rigidbody _rb;

    public float speed;

    public Camera pCam;

    public GameObject booster1; public GameObject booster2;

    public GameObject explosion;


    public float oobTimerf;
    public int oobTimerInt;
    public int timeLeft;


    public float health;
    public int damage;

    public bool canShoot;
    public int fireRate;
    public Image heatBar;

    public SpriteRenderer _spr;

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
        timeLeft = 5;
    }
	
	// Update is called once per frame
	void Update () {

        if(health > 30)
        {
            health = 30;
        }

        if(_spr.color == Color.red)
        {
            Invoke("ResetColor", 0.5f);
        }

        if(transform.position.x < 800 && transform.position.x > -800 && transform.position.z < 800 && transform.position.z > -800)
        {
            timeLeft = 5;
            oobTimerf = 0;
            GameManager.instance.outOfBounds.SetActive(false);
        }

        if(GameManager.instance.paused == false && GameManager.instance.alive == true)
        {


            health -= 0.01f;

            transform.position += pCam.transform.up * speed;
            if(transform.position.z > 800)
            {
                GameManager.instance.outOfBounds.SetActive(true);
                oobTimerf = oobTimerf + Time.deltaTime;
                oobTimerInt = Mathf.RoundToInt(oobTimerf);
                timeLeft = 5 - oobTimerInt;
                GameManager.instance.timerText.text = "" + timeLeft;
            }
            if (transform.position.z < -800)
            {
                GameManager.instance.outOfBounds.SetActive(true);
                oobTimerf = oobTimerf + Time.deltaTime;
                oobTimerInt = Mathf.RoundToInt(oobTimerf);
                timeLeft = 5 - oobTimerInt;
                GameManager.instance.timerText.text = "" + timeLeft;
            }
            if (transform.position.x > 800)
            {
                GameManager.instance.outOfBounds.SetActive(true);
                oobTimerf = oobTimerf + Time.deltaTime;
                oobTimerInt = Mathf.RoundToInt(oobTimerf);
                timeLeft = 5 - oobTimerInt;
                GameManager.instance.timerText.text = "" + timeLeft;
            }

            if(timeLeft <= 0)
            {
                Invoke("GameOver", 0f);
            }
            if (transform.position.x < -800)
            {
                GameManager.instance.outOfBounds.SetActive(true);
                oobTimerf = oobTimerf + Time.deltaTime;
                oobTimerInt = Mathf.RoundToInt(oobTimerf);
                timeLeft = 5 - oobTimerInt;
                GameManager.instance.timerText.text = "" + timeLeft;
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
  

            if (canShoot == true && Input.GetKey(KeyCode.W))
            {
                speed = 5;
                booster1.SetActive(true);
                booster2.SetActive(true);
                heatBar.fillAmount -= 0.01f;
            }
            if(canShoot == false || Input.GetKeyUp(KeyCode.W))
            {
                speed = 2;
                booster1.SetActive(false);
                booster2.SetActive(false);
            }
            if(fireRate > 0)
            {
                fireRate--;
            }
            #endregion
        }

        if(health <= 0 && GameManager.instance.alive == true)
        {
            Invoke("GameOver", 0f);
        }
    }

    private void ResetColor()
    {
        _spr.color = Color.white;
    }

    public void GameOver()
    {
        Instantiate(explosion, this.transform.position, Quaternion.identity);
        _spr.enabled = false;
        GameManager.instance.GameOver();
    }
}
