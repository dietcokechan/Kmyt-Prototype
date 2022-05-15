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
        // Grab components
        anim = GetComponentInChildren<Animator>();
        oathHandler = tree.GetComponentInChildren<OathHandler>();
    }

    void Update()
    {
        // by default play the idle animation
        Idle();

        // if the player is near and enemy can attack then play attack animation
        if(canAttack && playerNear)
        {
            Attack();
        }
        // if the player is near but has read the oath then play the back to idle animation
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

        // if the oath is not read then enemy can attack
        if(!oathHandler.oathRead)
        {
            canAttack = true;
        }

        // if the oath is read then enemy cannot attack
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
