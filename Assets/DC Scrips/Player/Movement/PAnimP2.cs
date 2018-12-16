using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PAnimP2 : PlayerAnimBase {
    Animator anim;
    public string horizontal = "HorizontalP2";
    public string vertical = "VerticalP2";
    public string sprint = "SprintP2";
    public PlayerAttack attack;
    public string attackButton = "FireP2";
    TrailRenderer attackTrail;


    // Use this for initialization
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        attack = gameObject.GetComponentInChildren<PlayerAttack>();
        attackTrail = gameObject.GetComponentInChildren<TrailRenderer>();


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis(vertical) > 0)
        {
            anim.SetBool("Forward", true);
            anim.SetBool("Backward", false);

        }



        if (Input.GetAxis(vertical) < 0)
        {
            anim.SetBool("Forward", false);
            anim.SetBool("Backward", true);

        }

        if (Input.GetAxis(vertical) < 1 & Input.GetAxis(vertical) > -1)
        {
            anim.SetBool("Forward", false);
            anim.SetBool("Backward", false);

        }

        if (Input.GetAxis(vertical) > 0 & Input.GetAxis(horizontal) > 0)
        {
            anim.SetBool("Forward", true);
            anim.SetBool("Backward", false);

        }

        if (Input.GetAxis(vertical) > 0 & Input.GetAxis(horizontal) < 0)
        {
            anim.SetBool("Forward", true);
            anim.SetBool("Backward", false);

        }

        if (Input.GetAxis(vertical) < 0 & Input.GetAxis(horizontal) < 0)
        {
            anim.SetBool("Forward", false);
            anim.SetBool("Backward", true);

        }

        if (Input.GetAxis(vertical) < 0 & Input.GetAxis(horizontal) > 0)
        {
            anim.SetBool("Forward", false);
            anim.SetBool("Backward", true);

        }

        if (Input.GetAxis(horizontal) < 0)
        {
            anim.SetBool("Left", true);
            anim.SetBool("Right", false);

        }

        if (Input.GetAxis(horizontal) > 0)
        {
            anim.SetBool("Left", false);
            anim.SetBool("Right", true);

        }

        if (Input.GetAxis(horizontal) < 1 && Input.GetAxis(horizontal) > -1)
        {
            anim.SetBool("Left", false);
            anim.SetBool("Right", false);

        }

        if (Input.GetButton(sprint) && Input.GetAxis(vertical) > 0)
        {
            anim.SetBool("Sprinting", true);
        }

        else
        {
            anim.SetBool("Sprinting", false);
        }

        if (!Input.GetButton(sprint) && Input.GetAxis(vertical) < 1)
        {
            anim.SetBool("Sprinting", false);
        }

        if (Input.GetButtonDown(attackButton) && !anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            anim.SetBool("Main Attack", true);

        }

        if (!Input.GetButtonDown(attackButton))
        {
            anim.SetBool("Main Attack", false);
        }

    }

    public override void AttackHit()
    {
        attack.Hit();
    }

    public override void AttackEnd()
    {
        attack.AEnd();
    }

    /*Upublic void StreamBegin()
    {
        attackTrail.enabled = true; 

    }

    public void StreamEnd()
    {
        attackTrail.enabled = false;
    }*/
}
