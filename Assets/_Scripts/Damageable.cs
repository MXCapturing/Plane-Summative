using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Damageable : MonoBehaviour {

    public int maxHP;
    public int currentHP;
    //public Image hpBar;

    // Use this for initialization
    void Start ()
    {
        currentHP = maxHP;
	}
	
    public void doDamage(int damage)
    {
        currentHP -= damage;
        //hpBar.fillAmount = currentHP / maxHP;
        if (currentHP <= 0)
        {
            GameManager.instance.score += 50;
            Destroy(gameObject);
        }
    }
}
