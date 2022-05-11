using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // VARIABLES
    [SerializeField] private float speed;
    [SerializeField] private float horizontalInput;
    [SerializeField] private float verticalInput;

    // COMPONENTS
    private Animator anim;
    private AudioSource audioSrc;
    private AudioClip footsteps;
    private Rigidbody rb;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        audioSrc = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        // Direction in 2D space for movement
        Vector3 directionTwo = new Vector3(horizontalInput, verticalInput, 0);

        // Direction in 3D space for rotation
        Vector3 directionThree = new Vector3(horizontalInput, 0, verticalInput);

        // If player is moving in 2D space rotate the player in 3D space
        if (directionTwo != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(directionThree);

            Walk();

            // if (!audioSrc.isPlaying)
            // {
            //     // Play footsteps
            //     audioSrc.clip = footsteps;
            //     audioSrc.Play();
            // }
        }
        else
        {
            Idle();
        }

        // Move the player
        rb.velocity = directionTwo * speed;
    }

    void Idle()
    {
        // Play idle animation
        anim.SetFloat("Speed", 0);
    }

    void Walk()
    {
        // Play walk animation
        anim.SetFloat("Speed", 1);
    }

    void Stop()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

    // Stop moving when the player is touching a collider
    void OnCollisionEnter(Collision collision)
    {
        Stop();
    }
}
