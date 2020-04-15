using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    public GameObject fileManager;
    public GameObject typingManager;
    
    private FileManager fm;
    private TypingManager tm;

    public float spawnTime = 5f;
    private Vector2 spawnPosition;

    public List<Enemy> enemies;

    // Start is called before the first frame update
    void Start()
    {
        tm = typingManager.GetComponent<TypingManager>();
        fm = fileManager.GetComponent<FileManager>();
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    void Spawn()
    {
        spawnPosition.x = Random.Range(-3.5f, 3.5f);
        spawnPosition.y = 3.5f;

        GameObject enem = Instantiate(enemy, spawnPosition, Quaternion.identity) as GameObject;
        string randomWord = fm.wordSetter();
        //string randomWord = "cat";    //test same words

        enem.GetComponent<Enemy>().word = randomWord;
        enem.GetComponent<Enemy>().textbox.text = randomWord;

        tm.words.Add(new Word(randomWord));
        tm.wordList.Add(randomWord);
        enemies.Add(enem.GetComponent<Enemy>());
    }

    public void findEnemy(string word)
    {
        for (int i = 0; i < enemies.Count; i++)
        {
            if (enemies[i].word == word)
            {
                enemies[i].shield = false;
                SoundManager.PlaySound("enemyShieldBreak");
                Destroy(enemies[i].GetComponentInChildren<SpriteRenderer>());
                Destroy(enemies[i].textbox);

                enemies.RemoveAt(i);
                tm.wordList.RemoveAt(i);
            }

        }
    }

    private void removeWord()
    {

    }
}
