using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBulletEnemy : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerMovement.instance.health -= 5;
            Destroy(gameObject);
        }
    }
}
