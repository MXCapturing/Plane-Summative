using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RapidRocket : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        GameObject objectCollided = other.gameObject;
        Damageable damageableComponent = objectCollided.GetComponent<Damageable>();

        if (damageableComponent)
        {
            damageableComponent.doDamage(20);
            GameManager.instance.score += 20;
            Destroy(gameObject);
        }
    }
}
