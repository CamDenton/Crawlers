using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CharacterController))]
public class PlayerMov : PlayerMovBase {

    public float speed;
    public float currentSpeed; 
    CharacterController controller;
    float translation = 0f;
    float strafe = 0f;
    public string horizontal = "HorizontalP1";
    public string vertical = "VerticalP1";
    public string sprint = "SprintP1";
    PlayerStats stats;


    // Use this for initialization
    void Start () {
        
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
        stats = GetComponent<PlayerStats>();
        //speed = stats.playerClassType.speed;
        speed = stats.playerClassType.Speed;
        currentSpeed = speed;
        stats.CurrentStamina = stats.MaxStamina;


    }
	
	// Update is called once per frame
	void Update () {
        Vector3 fwd = Input.GetAxis(vertical) * transform.TransformDirection(Vector3.forward);
        Vector3 right = Input.GetAxis(horizontal) * transform.TransformDirection(Vector3.right);

        controller.SimpleMove(Physics.gravity);
        strafe = Input.GetAxis(horizontal) * Time.deltaTime * currentSpeed;
        translation = Input.GetAxis(vertical) * Time.deltaTime * currentSpeed;

        if (controller.isGrounded)
        {
            transform.Translate(strafe, 0, translation);
        }
        

        //speed = Mathf.Clamp(speed, 0, 16);

        Debug.Log("Stats is " + stats);

        if (Input.GetButton(sprint) && Input.GetAxis(vertical) > 0 && stats.CurrentStamina > 0)
        {
            Sprint();
            stats.CurrentStamina--;
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
        if (stats.CurrentStamina <= stats.MaxStamina)

        {
            
            stats.CurrentStamina++;
        }


    }


}
