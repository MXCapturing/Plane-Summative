using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private Rigidbody _rb;

    public float speed;

    public Camera pCam;
    public GameObject bullet; public GameObject bullet2;
    public GameObject rocket; public GameObject rocket2;
    public GameObject laser; public GameObject laser2;

    private Quaternion qrotation;
    public float fireRate;
    public float maxFireRate;

    public int health;
    public int damage;

	// Use this for initialization
	void Start () {
        _rb = this.GetComponent<Rigidbody>();
        maxFireRate = 60;
        health = 30;
        damage = 1;
	}
	
	// Update is called once per frame
	void Update () {

        qrotation = this.transform.rotation;

        if (Input.GetKey(KeyCode.W))
        {
            // _rb.AddForce(pCam.transform.up * speed);
            transform.position += pCam.transform.up * speed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.eulerAngles += new Vector3(0, -2f, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.eulerAngles += new Vector3(0, 2f, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            //_rb.AddForce(pCam.transform.up * speed * -1);
            transform.position -= pCam.transform.up * speed;
        }
        #region Damage
        if (Input.GetKey(KeyCode.Space) && fireRate <= 0 && damage == 1)
        {
            Instantiate(bullet, this.transform.position, qrotation);
            fireRate = maxFireRate;
        }
        if (Input.GetKey(KeyCode.Space) && fireRate <= 0 && damage == 2)
        {
            Instantiate(bullet2, this.transform.position, qrotation);
            fireRate = maxFireRate;
        }
        if (Input.GetKey(KeyCode.Space) && fireRate <= 0 && damage == 3)
        {
            Instantiate(rocket, this.transform.position, qrotation);
            fireRate = maxFireRate;
        }
        if (Input.GetKey(KeyCode.Space) && fireRate <= 0 && damage == 4)
        {
            Instantiate(rocket2, this.transform.position, qrotation);
            fireRate = maxFireRate;
        }
        if (Input.GetKey(KeyCode.Space) && fireRate <= 0 && damage == 5)
        {
            Instantiate(laser, this.transform.position, qrotation);
            fireRate = maxFireRate;
        }
        if (Input.GetKey(KeyCode.Space) && fireRate <= 0 && damage == 6)
        {
            Instantiate(laser2, this.transform.position, qrotation);
            fireRate = maxFireRate;
        }
        #endregion
        if (fireRate > 0)
        {
            fireRate--;
        }
        if(health <= 0)
        {
            GameManager.instance.GameOver();
        }
    }
}
