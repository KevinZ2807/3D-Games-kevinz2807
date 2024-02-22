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
    private float minDirection = 0.5f;
    
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
        if (other.gameObject.tag == "Player") {
            Vector3 newDirection = (transform.position - other.transform.position).normalized;

            // Mathf.Sign: Return a value 0, -1 or 1 depends on the "x" value is negative or positive or zero
            // Mathf.Max: Return the largest value between 2 values
            newDirection.x = Mathf.Sign(newDirection.x) * Mathf.Max(Mathf.Abs(newDirection.x), minDirection);
            newDirection.z = Mathf.Sign(newDirection.z) * Mathf.Max(Mathf.Abs(newDirection.z), minDirection);
            direction = newDirection;
            return;
        }
        var firstContact = other.contacts[0];
        Debug.Log(other.contacts[0].normal);
        Vector3 newVelocity = Vector3.Reflect(direction.normalized, firstContact.normal); // Reflect to the wall it hits
        direction = newVelocity; // Change direction base on the reflection
        
    }

}
