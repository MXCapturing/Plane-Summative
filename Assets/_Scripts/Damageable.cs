using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Damageable : MonoBehaviour {

    public int maxHP;
    public int currentHP;
    private int dropChance;
    private int powerUp;

    public GameObject explosion;
    public GameObject damageUp;
    public GameObject hpUp;

    // Use this for initialization
    void Start ()
    {
        currentHP = maxHP;
	}
	
    public void doDamage(int damage)
    {
        currentHP -= damage;
        if (currentHP <= 0)
        {
            GameManager.instance.score += 50;
            PlayerMovement.instance.health += 5;

            powerUp = Random.Range(0, 2);
            dropChance = Random.Range(0, 20);
            if(dropChance >= 15 && powerUp == 0)
            {
                Instantiate(damageUp, this.transform.position, Quaternion.identity);
            }
            if(dropChance >= 15 && powerUp >= 1)
            {
                Instantiate(hpUp, this.transform.position, Quaternion.identity);
            }
            Instantiate(explosion, this.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
