﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovP4 : PlayerMovBase {
    public float speed;
    public float currentSpeed;
    CharacterController controller;
    float translation = 0f;
    float strafe = 0f;
    public string horizontal = "HorizontalP4";
    public string vertical = "VerticalP4";
    public string sprint = "SprintP4";
    public Slider staminaBar;
    PlayerStats playerStats;


    // Use this for initialization
    void Start()
    {
        controller = GetComponent<CharacterController>();
        currentSpeed = speed;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
        playerStats = GetComponent<PlayerStats>();
        playerStats.CurrentStamina = playerStats.MaxStamina;


    }

    // Update is called once per frame
    void Update()
    {
        Vector3 fwd = Input.GetAxis(vertical) * transform.TransformDirection(Vector3.forward);
        Vector3 right = Input.GetAxis(horizontal) * transform.TransformDirection(Vector3.right);

        controller.SimpleMove(Physics.gravity);
        strafe = Input.GetAxis(horizontal) * Time.deltaTime * currentSpeed;
        translation = Input.GetAxis(vertical) * Time.deltaTime * currentSpeed;
        transform.Translate(strafe, 0, translation);

        speed = Mathf.Clamp(speed, 0, 16);
        staminaBar.value = playerStats.CurrentStamina;



        if (Input.GetButton(sprint) && Input.GetAxis(vertical) > 0 && playerStats.CurrentStamina > 0)
        {
            Sprint();
            playerStats.CurrentStamina--;
        }

        else
        {
            currentSpeed = speed;
            RecoverStamina();
        }



    }



    public override void Sprint()
    {
        currentSpeed = speed * 2;



    }

    public override void RecoverStamina()
    {
        if (playerStats.CurrentStamina <= playerStats.MaxStamina)

        {

            playerStats.CurrentStamina++;
        }


    }
}
