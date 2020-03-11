using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Rigidbody2D rb;
    Vector2 movement;

    public int damage = 40;
    public string word = "cat";

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
            Destroy(gameObject);
        }
        else if (other.tag == "Bullet")
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}
