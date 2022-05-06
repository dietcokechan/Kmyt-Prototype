using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    private float horizontalInput;
    private float verticalInput;

    private Animator anim;
    public AudioSource audioSrc;
    public AudioClip footsteps;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        audioSrc = GetComponent<AudioSource>();
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
        verticalInput = 0;
        horizontalInput = 0;
    }
}
