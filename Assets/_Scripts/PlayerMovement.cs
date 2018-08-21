using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {

    public static PlayerMovement instance = null;

    //private Rigidbody _rb;

    public float speed;
    public float defaultSpeed;

    public Camera pCam;

    public GameObject booster1; public GameObject booster2;

    public GameObject explosion;

    public AudioSource boostMaker;
    public AudioClip boost;

    public float oobTimerf;
    public int oobTimerInt;
    public int timeLeft;

    public float dmgTimer;


    public float health;
    public float maxHealth;
    public int damage;

    public bool canShoot;
    public int fireRate;
    public Image heatBar;

    public SpriteRenderer _spr;
    public SpriteRenderer _sprLeft;
    public SpriteRenderer _sprRight;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

	// Use this for initialization
	void Start () {
        damage = 1;
        timeLeft = 5;
        boostMaker.clip = boost;
        health = maxHealth;
        speed = defaultSpeed;
    }
	
	// Update is called once per frame
	void Update () {

        if(health > maxHealth)
        {
            health = maxHealth;
        }

        if(_spr.color == Color.red || _sprLeft.color == Color.red || _sprRight.color == Color.red)
        {
            Invoke("ResetColor", 0.5f);
        }

        if(transform.position.x < 1000 && transform.position.x > -1000 && transform.position.z < 1000 && transform.position.z > -1000)
        {
            timeLeft = 5;
            oobTimerf = 0;
            GameManager.instance.outOfBounds.SetActive(false);
        }

        if(GameManager.instance.paused == false && GameManager.instance.alive == true)
        {


            health -= 0.01f;

            transform.position += pCam.transform.up * speed;
            if(transform.position.z > 1000)
            {
                GameManager.instance.outOfBounds.SetActive(true);
                oobTimerf = oobTimerf + Time.deltaTime;
                oobTimerInt = Mathf.RoundToInt(oobTimerf);
                timeLeft = 5 - oobTimerInt;
                GameManager.instance.timerText.text = "" + timeLeft;
            }
            if (transform.position.z < -1000)
            {
                GameManager.instance.outOfBounds.SetActive(true);
                oobTimerf = oobTimerf + Time.deltaTime;
                oobTimerInt = Mathf.RoundToInt(oobTimerf);
                timeLeft = 5 - oobTimerInt;
                GameManager.instance.timerText.text = "" + timeLeft;
            }
            if (transform.position.x > 1000)
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
            if (transform.position.x < -1000)
            {
                GameManager.instance.outOfBounds.SetActive(true);
                oobTimerf = oobTimerf + Time.deltaTime;
                oobTimerInt = Mathf.RoundToInt(oobTimerf);
                timeLeft = 5 - oobTimerInt;
                GameManager.instance.timerText.text = "" + timeLeft;
            }
            if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.W))
            {
                this.transform.eulerAngles += new Vector3(0, 2f, 0);
                _spr.enabled = false;
                _sprRight.enabled = true;
            }
            if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.W))
            {
                this.transform.eulerAngles += new Vector3(0, -2f, 0);
                _spr.enabled = false;
                _sprLeft.enabled = true;
            }
            if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W))
            {
                this.transform.eulerAngles += new Vector3(0, -4f, 0);
                _spr.enabled = false;
                _sprLeft.enabled = true;
            }
            if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W))
            {
                this.transform.eulerAngles += new Vector3(0, 4f, 0);
                _spr.enabled = false;
                _sprRight.enabled = true;
            }
            if(!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
            {
                _spr.enabled = true;
                _sprLeft.enabled = false;
                _sprRight.enabled = false;
            }
            if (Input.GetKey(KeyCode.S) && canShoot == true)
            {
                if(Input.GetKeyDown(KeyCode.S) && canShoot == true)
                {
                    speed = defaultSpeed - 1;
                }
                booster1.SetActive(false);
                booster2.SetActive(false);
                boostMaker.Stop();
                if (!Input.GetKey(KeyCode.Space))
                {
                    heatBar.fillAmount += 0.003f;
                }
            }
            if(Input.GetKeyUp(KeyCode.S) && !Input.GetKey(KeyCode.W))
            {
                speed = defaultSpeed;
                heatBar.fillAmount += 0.002f;
            }
            if(canShoot == false && Input.GetKey(KeyCode.S))
            {
                if (canShoot == false && Input.GetKeyDown(KeyCode.S))
                {
                    speed = defaultSpeed - 1.5f;
                }
                heatBar.fillAmount += 0.005f;
                if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
                {
                    this.transform.eulerAngles += new Vector3(0, -0.05f, 0);
                    _spr.enabled = false;
                    _sprLeft.enabled = true;
                }
                if (Input.GetKey(KeyCode.D))
                {
                    this.transform.eulerAngles += new Vector3(0, 0.05f, 0);
                    _spr.enabled = false;
                    _sprRight.enabled = true;
                }
            }
            #region Damage
  
            if(canShoot == true && Input.GetKeyDown(KeyCode.W) && !Input.GetKey(KeyCode.S))
            {
                boostMaker.Play();
            }
            if (canShoot == true && Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
            {
                if (canShoot == true && Input.GetKeyDown(KeyCode.W) && !Input.GetKey(KeyCode.S))
                {
                    speed = defaultSpeed * 1.4f;
                }
                booster1.SetActive(true);
                booster2.SetActive(true);
                heatBar.fillAmount -= 0.005f;
            }
            if(canShoot == false && !Input.GetKey(KeyCode.S) || Input.GetKeyUp(KeyCode.W) && !Input.GetKey(KeyCode.S))
            {
                speed = defaultSpeed;
                booster1.SetActive(false);
                booster2.SetActive(false);
                boostMaker.Stop();
            }
            if(fireRate > 0)
            {
                fireRate--;
            }

            dmgTimer = dmgTimer + Time.deltaTime;
            if(dmgTimer >= 15)
            {
                damage--;
                dmgTimer = 0;
            }
            if(damage < 1)
            {
                damage = 1;
            }
            if(damage > 6)
            {
                damage = 6;
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
        _sprLeft.color = Color.white;
        _sprRight.color = Color.white;
    }

    public void GameOver()
    {
        Instantiate(explosion, this.transform.position, Quaternion.identity);
        _spr.enabled = false;
        _sprLeft.enabled = false;
        _sprRight.enabled = false;
        booster1.SetActive(false);
        booster2.SetActive(false);
        boostMaker.Stop();
        heatBar.enabled = false;
        GameManager.instance.GameOver();
    }
}
