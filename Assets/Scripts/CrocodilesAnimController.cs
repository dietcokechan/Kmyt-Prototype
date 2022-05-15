using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrocodilesAnimController : MonoBehaviour
{
    //VARIABLES
    private bool canAttack = true;
    private bool playerNear;

    //COMPONENTS
    private Animator anim;
    public GameObject tree;
    private OathHandler oathHandler;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        oathHandler = tree.GetComponentInChildren<OathHandler>();
    }

    void Update()
    {
        Idle();

        if(canAttack && playerNear)
        {
            Attack();
        }
        if(!canAttack && playerNear)
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

    void OnTriggerStay(Collider other)
    {
        playerNear = true;

        if(!oathHandler.oathRead)
        {
            canAttack = true;
        }

        if(oathHandler.oathRead)
        {
            canAttack = false;
        }
    }

    void OnTriggerExit(Collider other)
    {
        playerNear = false;
    }
}
