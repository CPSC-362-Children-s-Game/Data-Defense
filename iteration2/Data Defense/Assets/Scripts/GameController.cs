using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject player;
    public GameObject bullet;
    public static int wordLength = 0;

    // Start is called before the first frame update
    void Start() {
        
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            shoot();
        }
    }
    void shoot() {
        Vector3 position = player.transform.position;
        Quaternion rotation = player.transform.rotation;
        Instantiate(bullet, position, rotation);
    }
}
