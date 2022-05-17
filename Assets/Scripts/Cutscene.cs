using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Cutscene : MonoBehaviour
{
    public GameObject camera;
    private CinemachineVirtualCamera cmComponent;

    void Start()
    {
        cmComponent = camera.GetComponent<CinemachineVirtualCamera>();
    }

    void Update()
    {
    
    }

    void OnTriggerEnter(Collider other)
    {
        cmComponent.Priority = 11;
    }
}
