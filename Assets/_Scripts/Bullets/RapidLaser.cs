using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RapidLaser : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        GameObject objectCollided = other.gameObject;
        Damageable damageableComponent = objectCollided.GetComponent<Damageable>();

        if (damageableComponent)
        {
            damageableComponent.doDamage(30);
            GameManager.instance.score += 30;
            Destroy(gameObject);
        }
    }
}
