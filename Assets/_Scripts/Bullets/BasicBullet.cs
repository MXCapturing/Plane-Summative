using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBullet : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            GameObject objectCollided = other.gameObject;
            Damageable damageableComponent = objectCollided.GetComponent<Damageable>();

            if (damageableComponent)
            {
                damageableComponent.doDamage(5);
                GameManager.instance.score += 5;
                Destroy(gameObject);
            }
        }
    }
}
