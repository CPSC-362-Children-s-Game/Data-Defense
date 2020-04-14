using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip playerAttackSound, playerHitSound, playerDeathSound, 
        enemyImmuneSound, enemyDeathSound;
    static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        playerAttackSound = Resources.Load<AudioClip>("playerAttack");
        playerHitSound = Resources.Load<AudioClip>("playerHit");
        playerDeathSound = Resources.Load<AudioClip>("playerDeath");
        enemyImmuneSound = Resources.Load<AudioClip>("enemyImmune");

        enemyDeathSound = Resources.Load<AudioClip>("enemyDeath");

        audioSrc = GetComponent<AudioSource>();
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "playerAttack":
                audioSrc.PlayOneShot(playerAttackSound);
                break;
            case "playerHit":
                audioSrc.PlayOneShot(playerHitSound);
                break;
            case "playerDeath":
                audioSrc.PlayOneShot(playerDeathSound);
                break;
            case "enemyImmune":
                audioSrc.PlayOneShot(enemyImmuneSound);
                break;
            case "enemyDeath":
                audioSrc.PlayOneShot(enemyDeathSound);
                break;
        }
    }
}