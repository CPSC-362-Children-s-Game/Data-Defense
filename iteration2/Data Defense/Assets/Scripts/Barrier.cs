using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    public int barrierhealth = 100;
    float deathRate = 1.0f;
    float deathTime;
    bool dead = false;

    private void Update()
    {
        if (barrierhealth <= 0 && Time.time > deathTime && dead == false)
        {
            SoundManager.PlaySound("playerDeath");
            deathTime = Time.time + deathRate;
            dead = true;
        }
    }
}
