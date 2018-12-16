using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {

    public float Speed = 10f;

    public float Direction;

    float translation = 0f;

    float strafe = 0f; 

    Animator anim;

    GameObject player; 


	// Use this for initialization
	void Start () {

        anim = gameObject.GetComponent<Animator>();

        player = gameObject;
		
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown("w"))
            {
            translation = Input.GetAxis("Vertical") * Speed;

            translation *= Time.deltaTime;
        }

       

        if(Input.GetKeyDown("w"))
        {
            translation = Input.GetAxis("Vertical") * Speed;

            translation *= Time.deltaTime;
        }

        


        /*if(Input.GetAxis("Horizontal")>1)
        {
            strafe = Input.GetAxis("Horizontal") * Speed;

            strafe *= Time.deltaTime;
        }

        

        if (Input.GetAxis("Horizontal")<1)
        {
            strafe = Input.GetAxis("Horizontal") * Speed;

            strafe *= Time.deltaTime;
        }*/

        

        transform.Translate(strafe, 0f, translation);

        anim.SetFloat("Translation", translation);
        anim.SetFloat("Strafe", strafe);

        print("Translation");
        print("Strafe");
    }
}
