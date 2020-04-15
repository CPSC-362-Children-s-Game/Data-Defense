using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
   
    // Update is called once per frame
    void Update() {
        Vector3 horizontal = new Vector3(Input.GetAxis("Horizontal") * speed, 0.0f, 0.0f);

        if ((transform.position.x >= -4.0f && horizontal.x < 0) || (transform.position.x <= 4.0f && horizontal.x > 0)) {
            transform.position = transform.position + horizontal * Time.deltaTime;
        }
    }
}
