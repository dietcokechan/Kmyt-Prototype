using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarAI : MonoBehaviour
{
    // VARIABLES
    private float speed = 12f;

    // COMPONENTS
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Moves automatically
        rb.velocity = Vector3.right * speed;
    }

    // Stop moving upon hitting colliders
    void OnCollisionEnter(Collision collision)
    {
        rb.velocity = Vector3.zero;
    }
}
