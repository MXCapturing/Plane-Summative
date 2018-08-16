using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {

    public GameObject bullet; public GameObject bullet2;
    public GameObject rocket; public GameObject rocket2;
    public GameObject laser; public GameObject laser2;

    public GameObject muzzleFlash;

    private Quaternion qrotation;

    public AudioSource audioSource;
    public AudioClip bulletSound;
    public AudioClip rocketSound;
    public AudioClip laserSound;

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {

        qrotation = this.transform.rotation;

        if (PlayerMovement.instance.canShoot == true && PlayerMovement.instance.fireRate <= 0)
        {
            if (Input.GetKey(KeyCode.Space) && PlayerMovement.instance.damage == 1)
            {
                audioSource.clip = bulletSound;
                audioSource.Play();
                Instantiate(muzzleFlash, this.transform.position, qrotation);
                Instantiate(bullet, this.transform.position, qrotation);
                PlayerMovement.instance.heatBar.fillAmount -= 0.02f;
                PlayerMovement.instance.fireRate = 5;
            }
            if (Input.GetKey(KeyCode.Space) && PlayerMovement.instance.damage == 2)
            {
                audioSource.clip = bulletSound;
                audioSource.Play();
                Instantiate(muzzleFlash, this.transform.position, qrotation);
                Instantiate(bullet2, this.transform.position, qrotation);
                PlayerMovement.instance.heatBar.fillAmount -= 0.01f;
                PlayerMovement.instance.fireRate = 5;
            }
            if (Input.GetKey(KeyCode.Space) && PlayerMovement.instance.damage == 3)
            {
                audioSource.clip = rocketSound;
                audioSource.Play();
                Instantiate(muzzleFlash, this.transform.position, qrotation);
                Instantiate(rocket, this.transform.position, qrotation);
                PlayerMovement.instance.heatBar.fillAmount -= 0.01f;
                PlayerMovement.instance.fireRate = 5;
            }
            if (Input.GetKey(KeyCode.Space) && PlayerMovement.instance.damage == 4)
            {
                audioSource.clip = rocketSound;
                audioSource.Play();
                Instantiate(muzzleFlash, this.transform.position, qrotation);
                Instantiate(rocket2, this.transform.position, qrotation);
                PlayerMovement.instance.heatBar.fillAmount -= 0.01f;
                PlayerMovement.instance.fireRate = 5;
            }
            if (Input.GetKey(KeyCode.Space) && PlayerMovement.instance.damage == 5)
            {
                audioSource.clip = laserSound;
                audioSource.Play();
                Instantiate(muzzleFlash, this.transform.position, qrotation);
                Instantiate(laser, this.transform.position, qrotation);
                PlayerMovement.instance.heatBar.fillAmount -= 0.01f;
                PlayerMovement.instance.fireRate = 5;
            }
            if (Input.GetKey(KeyCode.Space) && PlayerMovement.instance.damage >= 6)
            {
                audioSource.clip = laserSound;
                audioSource.Play();
                Instantiate(muzzleFlash, this.transform.position, qrotation);
                Instantiate(laser2, this.transform.position, qrotation);
                PlayerMovement.instance.heatBar.fillAmount -= 0.01f;
                PlayerMovement.instance.fireRate = 5;
            }
            if (!Input.GetKey(KeyCode.Space) && !Input.GetKeyDown(KeyCode.LeftControl))
            {
                PlayerMovement.instance.heatBar.fillAmount += 0.003f;
            }
        }
    }
}
