using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float horizontalInput;
    [SerializeField] private float verticalInput;
    public bool canMove = true;

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

    void FixedUpdate()
    {
        if (!canMove)
        {
            Stop();
        }
        else
        {
            Move();
        }
    }

    void Move()
    {
        canMove = true;

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

            if (!audioSrc.isPlaying)
            {
                audioSrc.clip = footsteps;
                audioSrc.Play();
            }
        }
        else
        {
            Idle();
        }

        // Move the player
        transform.Translate(directionTwo * Time.deltaTime * speed, Space.World);
    }

    void Idle()
    {
        // Idle Animtion
        anim.SetFloat("Speed", 0);
    }

    void Walk()
    {
        // Walk Animtion
        anim.SetFloat("Speed", 1);
    }

    void Stop()
    {
        canMove = false;
        rb.velocity = Vector3.zero;
    }

    void OnCollisionEnter(Collision collision)
    {
        if(canMove)
        {
            Stop();
        }
    }
}
