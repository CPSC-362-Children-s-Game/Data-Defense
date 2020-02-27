using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        Vector3 horizontal = new Vector3(Input.GetAxis("Horizontal") * speed, 0.0f, 0.0f);
        transform.position = transform.position + horizontal * Time.deltaTime;
    }
}
