using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPUp : MonoBehaviour {

    public AudioClip powerUp;
    public AudioSource powerSource;

    public SpriteRenderer _spr;
    public Collider _col;

    private void Start()
    {
        powerSource.clip = powerUp;
        Invoke("Destroy", 5);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            powerSource.Play();
            PlayerMovement.instance.health += 10;
            _spr.enabled = false;
            _col.enabled = false;
            Invoke("Destroy", 1);
        }
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }
}
