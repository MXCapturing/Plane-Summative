using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicRocketEnemy : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerMovement.instance.health -= 15;
            Destroy(gameObject);
        }
    }
}
