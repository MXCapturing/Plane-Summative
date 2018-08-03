using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicLaser : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        GameObject objectCollided = other.gameObject;
        Damageable damageableComponent = objectCollided.GetComponent<Damageable>();

        if (damageableComponent)
        {
            damageableComponent.doDamage(25);
            GameManager.instance.score += 25;
            Destroy(gameObject);
        }
    }
}
