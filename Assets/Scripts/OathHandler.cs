using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OathHandler : MonoBehaviour
{
    public bool oathRead;

    void Start()
    {
        oathRead = false;
    }

    void OnTriggerStay(Collider other)
    {
        oathRead = true;
    }
}