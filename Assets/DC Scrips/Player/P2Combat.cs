using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class P2Combat : MonoBehaviour {

    PAnimP2 pAnims;
    Animator anim;
    PlayerMovP2 playerMovement;
    PlayerStats playerStats;
    CharacterController controller;
    public Slider healthBar;
    public Slider staminaBar;
    public Image damagedImage;
    public bool isDead;




    // Use this for initialization
    void Start()
    {

        anim = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        playerMovement = GetComponent<PlayerMovP2>();
        playerStats = GetComponent<PlayerStats>();
        playerStats.CurrentHealth = playerStats.MaxHealth;
        pAnims = GetComponent<PAnimP2>();




    }

    // Update is called once per frame
    void Update()
    {

        Debug.Log(playerStats.playerClassType + " This is the players class");


    }



    public void Hit(int damage)
    {
        playerStats.CurrentHealth = playerStats.CurrentHealth - damage;

        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Hit"))
        {
            anim.Play("Hit");
            controller.Move(controller.transform.forward * -10);

        }



        if (playerStats.CurrentHealth <= 0)
        {
            Death();

        }

        else
        {

        }

    }

    void Death()
    {
        playerMovement.enabled = false;
        anim.SetBool("Dead", true);
        anim.Play("Death");
        pAnims.enabled = false;

    }

    void Respawn()
    {
        isDead = false;
        playerStats.CurrentHealth = playerStats.MaxHealth / 4;
        playerMovement.enabled = true;
        anim.SetBool("Dead", false);
        pAnims.enabled = true;
    }

    void Interact()
    {
        if (isDead == true)
        {
            Respawn();
        }
    }
}
