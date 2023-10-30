using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    // initializing variables
    [SerializeField] float steerSpeed = 150f;
    [SerializeField] float boostSpeed = 30f;
    [SerializeField] float moveSpeed = 20f;
    [SerializeField] float bumpSpeed = 10f;

    // Update is called once per frame
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount);
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Translate(0, moveAmount, 0);
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        moveSpeed = bumpSpeed;
    }
    
    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Boost")
        {
            moveSpeed = boostSpeed;
        }
        
        if (other.tag == "Normal")
        {
            moveSpeed = 20f;
        }

        if (other.tag == "Bump")
        {
            moveSpeed = bumpSpeed;
        }
    }
}
