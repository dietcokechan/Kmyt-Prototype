using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastPart : MonoBehaviour
{
    public GameObject camera;
    private Animation anim;

    void Start()
    {
        anim = camera.GetComponent<Animation>();
    }

    // When entering trigger collider zoom out!!!!!!!!!!!
    void OnTriggerEnter(Collider other)
    {
        anim.Play("Cutscene");
    }
}
