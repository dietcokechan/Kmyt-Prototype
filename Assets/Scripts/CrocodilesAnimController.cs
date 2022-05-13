using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrocodilesAnimController : MonoBehaviour
{
    //VARIABLES
    private bool canAttack = true;
    private bool playerNear;
    private bool oathRead;

    //COMPONENTS
    private Animator anim;
    public GameObject tree;
    private OathHandler oathHandler;

    void Start()
    {
        anim = GetComponent<Animator>();
        oathHandler = GetComponent<OathHandler>();
        oathRead = oathHandler.oathRead;
    }

    void Update()
    {
        if(!playerNear)
        {
            Idle();
        }
        if(canAttack && playerNear)
        {
            Attack();
        }
        else if(oathRead)
        {
            BackToIdle();
        }
    }

    void Attack()
    {
        anim.SetFloat("Move", 1);
    }

    void BackToIdle()
    {
        anim.SetFloat("Move", -1);
    }

    void Idle()
    {
        anim.SetFloat("Move", 0);
    }

    void OnTriggerEnter(Collider other)
    {
        playerNear = true;

        if(!oathRead)
        {
            canAttack = true;
        }
        else if(oathRead)
        {
            canAttack = false;
        }
    }

    void OnTriggerExit(Collider other)
    {
        playerNear = false;
    }
}
