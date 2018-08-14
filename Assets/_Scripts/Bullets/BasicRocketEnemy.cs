﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicRocketEnemy : MonoBehaviour {

    public float destroyTimer;
    public int damage;

    public GameObject impact;

    void Start()
    {
        Invoke("BulletDrop", destroyTimer);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Instantiate(impact, this.transform.position, this.transform.rotation);
            PlayerMovement.instance.health -= damage;
            Destroy(gameObject);
        }
    }

    void BulletDrop()
    {
        Destroy(gameObject);
    }
}
