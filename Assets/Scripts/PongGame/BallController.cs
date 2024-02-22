using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody rb;
    
    [Header("Attributes")]
    [SerializeField] private float speed;
    [SerializeField] private Vector3 direction;

    
    private float xRandom;
    private float zRandom;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        xRandom = Random.Range(-1f, 1f);
        zRandom = Random.Range(-1f, 1f);
        direction = new Vector3(xRandom, 0f, zRandom);
    }

    void FixedUpdate()
    {
        // Using Moving Kinematics
        //transform.position += direction * speed * Time.deltaTime;
        // or
        rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime); // Move the ball
    }


    private void OnCollisionEnter(Collision other) {
        var firstContact = other.contacts[0];
        Debug.Log(other.contacts[0].normal);
        Vector3 newVelocity = Vector3.Reflect(direction.normalized, firstContact.normal); // Reflect to the wall it hits
        direction = newVelocity; // Change direction base on the reflection
    }

}
