using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    public float spawnTime = 5f;
    private Vector2 spawnPosition;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    void Spawn()
    {
        spawnPosition.x = Random.Range(-3.5f, 3.5f);
        spawnPosition.y = 3.5f;

        Instantiate(enemy, spawnPosition, Quaternion.identity);
    }

  
}
