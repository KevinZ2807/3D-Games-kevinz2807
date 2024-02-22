using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacketController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody rb;
    [Header("Attributes")]
    [SerializeField] private float speed;
    
    private float vertical;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    void FixedUpdate()
    {
        vertical = Input.GetAxis("Vertical");

        rb.velocity = Vector3.forward * speed * vertical;
    }
}
