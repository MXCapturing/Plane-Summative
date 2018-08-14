using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBullet : MonoBehaviour {

    public float destroyTimer;
    public int damage;

    public GameObject impact;

    void Start()
    {
        Invoke("BulletDrop", destroyTimer);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            Instantiate(impact, this.transform.position, this.transform.rotation);
            GameObject objectCollided = other.gameObject;
            Damageable damageableComponent = objectCollided.GetComponent<Damageable>();

            if (damageableComponent)
            {
                damageableComponent.doDamage(damage);
                GameManager.instance.score += damage;
                Destroy(gameObject);
            }
        }
    }

    void BulletDrop()
    {
        Destroy(gameObject);
    }
}
