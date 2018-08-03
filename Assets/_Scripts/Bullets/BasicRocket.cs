using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicRocket : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            GameObject objectCollided = other.gameObject;
            Damageable damageableComponent = objectCollided.GetComponent<Damageable>();

            if (damageableComponent)
            {
                damageableComponent.doDamage(15);
                GameManager.instance.score += 15;
                Destroy(gameObject);
            }
        }
    }
}
