using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset = new Vector3(0, 0, -10);
    
    void Start()
    {
        
    }

    void Update()
    {
        transform.position = player.transform.position + offset;
    }
}
