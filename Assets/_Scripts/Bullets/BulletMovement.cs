﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour {

    public float speed;

	// Use this for initialization
	void Start () {
        Invoke("BulletDrop", 2);
	}
	
	// Update is called once per frame
	void Update () {
        if(GameManager.instance.paused == false && GameManager.instance.alive == true)
        {
            transform.position += transform.forward * speed;
        }
	}

    void BulletDrop()
    {
        Destroy(gameObject);
    }
}
