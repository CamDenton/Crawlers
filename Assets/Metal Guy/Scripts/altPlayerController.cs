using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class altPlayerController : MonoBehaviour {

    public float speed = 0f;

    public float direction;

    float translation = 0f;

    float strafe = 0f;

    float originalSpeed;

    Animator anim;

    GameObject player;
    CharacterController controller;


    // Use this for initialization
    void Start()
    {

        anim = gameObject.GetComponent<Animator>();

        player = gameObject;

        Cursor.lockState = CursorLockMode.Locked;
        
        Cursor.visible = true;

        originalSpeed = speed;

        controller = GetComponent<CharacterController>();

    }

        // Update is called once per frame
        void Update () {
        if(Input.GetKey("left ctrl"))
        {
            speed = speed * 2;
        }

        else
        {
            speed = originalSpeed;  
        }
        strafe = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        translation = Input.GetAxis("Vertical") * Time.deltaTime * speed;
        transform.Translate(strafe, 0, translation);

        speed = Mathf.Clamp(speed, 0, 8);

        print(speed);

        if (Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
        }

        controller.SimpleMove(Physics.gravity);

        




    }
}
