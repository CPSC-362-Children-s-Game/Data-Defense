using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Rigidbody2D rb;
    Vector2 movement;

    public int damage = 40;
    public string word = "cat";

    public bool shield = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        movement.x = 0f;
        movement.y = -0.5f;
    }

    void Update()
    {
        rb.MovePosition(rb.position + movement * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Barrier")
        {
            other.GetComponent<Barrier>().health -= damage;
            if (other.GetComponent<Barrier>().health > 0)
                SoundManager.PlaySound("playerHit");
            Destroy(gameObject);
        }
        else if (other.tag == "Bullet" && shield == false)
        {
            SoundManager.PlaySound("enemyDeath");
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
        else if (other.tag == "Bullet" && shield == true)
        {
            Destroy(other.gameObject);
            SoundManager.PlaySound("enemyImmune");
        }
    }
}
