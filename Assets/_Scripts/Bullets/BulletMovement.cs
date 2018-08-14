using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour {

    public float speed;
	
	// Update is called once per frame
	void Update () {
        if(GameManager.instance.paused == false && GameManager.instance.alive == true)
        {
            transform.position += transform.forward * speed;
        }
	}
}
