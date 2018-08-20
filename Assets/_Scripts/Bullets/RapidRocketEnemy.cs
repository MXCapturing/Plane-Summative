using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RapidRocketEnemy : MonoBehaviour {

    public float destroyTimer;
    public int damage;

    public AudioSource soundMaker;
    public AudioClip sound;

    public GameObject impact;

    public SpriteRenderer _spr;

    void Start()
    {
        Invoke("BulletDrop", destroyTimer);
        soundMaker.clip = sound;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            soundMaker.Play();
            PlayerMovement.instance._spr.color = Color.red;
            PlayerMovement.instance._sprLeft.color = Color.red;
            PlayerMovement.instance._sprRight.color = Color.red;
            Instantiate(impact, this.transform.position, this.transform.rotation);
            PlayerMovement.instance.health -= damage;
            Invoke("BulletDrop", 1);
            this.GetComponent<BulletMovement>().speed = 0;
            _spr.enabled = false;
        }
    }

    void BulletDrop()
    {
        Destroy(gameObject);
    }
}
