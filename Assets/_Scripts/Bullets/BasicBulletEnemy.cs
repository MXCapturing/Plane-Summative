using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBulletEnemy : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameObject objectCollided = other.gameObject;
            Damageable damageableComponent = objectCollided.GetComponent<Damageable>();

            if (damageableComponent)
            {
                damageableComponent.doDamage(5);
            }
        }
    }
}
