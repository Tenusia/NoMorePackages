using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 0.1f;
    [SerializeField] float moveSpeed = 20f;
    [SerializeField] float slowSpeed = 15f;
    [SerializeField] float boostSpeed = 30f;
    [SerializeField] float waitTime = 5f;
    [SerializeField] float startSpeed = 20f;

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "SpeedBoost")
        {
            moveSpeed = boostSpeed;
            Invoke("ReturnStartSpeed", waitTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        moveSpeed = slowSpeed;
        Invoke("ReturnStartSpeed", waitTime);  
    }

    // Update is called once per frame
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float speedAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0,0,-steerAmount);
        transform.Translate(0,speedAmount,0);
        
    }
    void ReturnStartSpeed()
    {
        moveSpeed = startSpeed;
    }
    
}
