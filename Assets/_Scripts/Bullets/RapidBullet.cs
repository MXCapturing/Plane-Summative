using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RapidBullet : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        GameObject objectCollided = other.gameObject;
        Damageable damageableComponent = objectCollided.GetComponent<Damageable>();

        if (damageableComponent)
        {
            damageableComponent.doDamage(10);
            GameManager.instance.score += 10;
            Destroy(gameObject);
        }
    }
}
