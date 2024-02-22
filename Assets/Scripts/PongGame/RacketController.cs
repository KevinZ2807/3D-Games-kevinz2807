using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacketController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Transform ball;
    [Header("Attributes")]
    [SerializeField] private float speed;
    [SerializeField] private bool isPlayer;
    [SerializeField] private float offset = 2f;
    public KeyCode up;
    public KeyCode down;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        ball = GameObject.FindGameObjectWithTag("Ball").transform;
    }

    private void FixedUpdate()
    {
        if (isPlayer) {
            MoveByPlayer(up, down);
        } else {
            MoveByComputer();
        }
    }

    private void MoveByPlayer(KeyCode upKey, KeyCode downKey)
    {
        var direction = 0f;
        if (Input.GetKey(upKey)) direction += 1f;
        if (Input.GetKey(downKey)) direction -= 1f;
        if (!Input.GetKey(upKey) && !Input.GetKey(downKey)) {
            rb.velocity = Vector3.zero;
            return;
        }

        rb.velocity += Vector3.forward * direction * speed * Time.deltaTime;
    }


    private void MoveByComputer() {
        if (ball.position.z != transform.position.z) {
        // Determine the direction to move in
        Vector3 moveDirection = (ball.position.z > transform.position.z 
        + Random.Range(-offset, offset)) ? Vector3.forward : Vector3.back;
        
        // Apply the movement
        rb.velocity = moveDirection * speed;
        }
        else {
            // Optionally, stop the movement if the positions are equal
            rb.velocity = Vector3.zero;
        }
    }
}
