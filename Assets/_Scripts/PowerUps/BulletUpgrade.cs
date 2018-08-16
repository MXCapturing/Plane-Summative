using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletUpgrade : MonoBehaviour {

    public AudioClip powerUp;
    public AudioSource powerSource;

    public SpriteRenderer _spr;

    private void Start()
    {
        powerSource.clip = powerUp;
        Invoke("Destroy", 3);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            powerSource.Play();
            PlayerMovement.instance.damage++;
            _spr.enabled = false;
            Invoke("Destroy", 1f);
        }
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }
}
