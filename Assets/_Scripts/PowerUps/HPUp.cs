using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPUp : MonoBehaviour {

    private void Start()
    {
        Invoke("Destroy", 3);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            PlayerMovement.instance.health += 10;
            Destroy(gameObject);
        }
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }
}
