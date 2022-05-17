using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    // VARIABLES
    private float speed = 15f;
    private float direction;

    // COMPONENTS
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        direction = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector3(direction * speed, 0, 0);
    }

    // Stop moving upon hitting colliders
    void OnCollisionEnter(Collision collision)
    {
        rb.velocity = Vector3.zero;
    }
}
