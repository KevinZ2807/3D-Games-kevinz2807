using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacketController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody rb;
    [Header("Attributes")]
    [SerializeField] private float speed;
    public KeyCode up;
    public KeyCode down;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        MovePlayer(up, down);
    }

    private void MovePlayer(KeyCode upKey, KeyCode downKey)
    {
        var direction = 0f;
        if (Input.GetKey(upKey)) direction += 1f;
        if (Input.GetKey(downKey)) direction -= 1f;

        transform.position += Vector3.forward * direction * speed * Time.deltaTime;
    }
}
