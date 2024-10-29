using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    private float speed = 3.0f;
    public int points = 0;
   
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        transform.position += new Vector3(horizontal * speed * Time.deltaTime, 0, vertical * speed * Time.deltaTime);
    }
}
