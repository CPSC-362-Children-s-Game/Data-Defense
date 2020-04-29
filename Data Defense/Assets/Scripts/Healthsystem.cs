using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Healthsystem : MonoBehaviour
{
    private float health;
    public float healthMax;
    public float curHealth;
    public GameObject healthBar;
    float deathRate = 1.0f;
    float deathTime;

    bool dead = false;

    //public event EventHandler HealthChanged;
    //public event EventHandler Dead;

    private void Start()
    {
        healthMax = 100f;
        health = healthMax;
    }

    private void Update()
    {
        curHealth = health;

        if (curHealth <= 0)
        {
            die();
        }
    }
    
    //private void Update()
    //{
    //    if (Input.GetKeyDown("up"))
    //    {
    //        Debug.Log("Taking damage");
    //        Damage(40f);
    //        updatehealthbar();
    //    }

    //}

    public float GetHealthpercent()
    {
        return health / healthMax;
    }

    public void Damage(float amount)
    {
        health -= amount;
        if (health < 0f)
        {
            health = 0f;
        }

        updatehealthbar();
        //if (HealthChanged != null) HealthChanged(this, EventArgs.Empt);
    }

    private void updatehealthbar()
    {
        healthBar.transform.localScale = new Vector3(GetHealthpercent() * healthBar.transform.localScale.x, healthBar.transform.localScale.y);
    }

    public void die()
    {
        if (Time.time > deathTime && dead == false)
        {
            SoundManager.PlaySound("playerDeath");
            deathTime = Time.time + deathRate;
            dead = true;
            Destroy(gameObject);
        }
    }
}
