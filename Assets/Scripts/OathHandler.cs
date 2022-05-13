using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OathHandler : MonoBehaviour
{
    public bool oathRead;

    void OnTriggerEnter(Collider other)
    {
        oathRead = true;
    }
}
