using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Damageable : MonoBehaviour {

    public float maxHP;
    public float currentHP;
    private int dropChance;
    private int powerUp;

    public GameObject explosion;
    public GameObject damageUp;
    public GameObject hpUp;

    public SpriteRenderer _spr;
    public Image hpBar;

    // Use this for initialization
    void Start ()
    {
        currentHP = maxHP;
	}

    private void Update()
    {
        hpBar.fillAmount = currentHP / maxHP;
    }
    public void doDamage(int damage)
    {
        _spr.color = Color.red;
        Invoke("ResetColor", 0.1f);
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

    private void ResetColor()
    {
        _spr.color = Color.white;
    }
}
