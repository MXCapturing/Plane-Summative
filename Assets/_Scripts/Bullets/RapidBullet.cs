using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RapidBullet : MonoBehaviour {

    public float destroyTimer;
    public int damage;

    public GameObject impact;

    public AudioClip impactSound;
    public AudioSource soundSource;

    public SpriteRenderer _spr;

    void Start()
    {
        Invoke("BulletDrop", destroyTimer);
        soundSource.clip = impactSound;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            soundSource.Play();
            Instantiate(impact, this.transform.position, this.transform.rotation);
            GameObject objectCollided = other.gameObject;
            Damageable damageableComponent = objectCollided.GetComponent<Damageable>();

            if (damageableComponent)
            {
                damageableComponent.doDamage(damage);
                GameManager.instance.score += damage;
                Invoke("BulletDrop", 1);
                this.GetComponent<BulletMovement>().speed = 0;
                _spr.enabled = false;
            }
        }
    }

    void BulletDrop()
    {
        Destroy(gameObject);
    }
}
