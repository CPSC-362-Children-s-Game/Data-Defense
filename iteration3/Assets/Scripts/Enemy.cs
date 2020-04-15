using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public Rigidbody2D rb;
    public Text textbox;
    //public GameObject fileManager;
    //public FileManager fm;

    Vector2 movement;

    public int damage = 40;
    public bool shield;
    public string word;

    void Start()
    {
        //FileManager fm = fileManager.GetComponent<FileManager>();

        rb = GetComponent<Rigidbody2D>();
        movement.x = 0f;
        movement.y = -0.5f;

        shield = true;

        ////Set Random 
        //int randomNumber = Random.Range(0, fileManager.GetComponent<FileManager>().namesArray.Length);
        //word = fileManager.GetComponent<FileManager>().namesArray[randomNumber];
        //textbox.text = word;
    }

    void Update()
    {
        rb.MovePosition(rb.position + movement * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Barrier")
        {
            Debug.Log("Collision found");
            other.GetComponent<Healthsystem>().Damage(40f);
            if (other.GetComponent<Healthsystem>().curHealth > 0)
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
