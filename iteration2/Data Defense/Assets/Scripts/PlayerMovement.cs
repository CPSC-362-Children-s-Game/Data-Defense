using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
   
    // Update is called once per frame
    void Update() {
        Vector3 horizontal = new Vector3(Input.GetAxis("Horizontal") * speed, 0.0f, 0.0f);
        transform.position = transform.position + horizontal * Time.deltaTime;

    }
}
