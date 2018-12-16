using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class PlayerRangedAttack : MonoBehaviour {

    public int DamageInt;
    Animator anim;
    public bool hasFired = false;
    public string attackButton = "FireP1";
    Vector3 parentPosition;
    public GameObject projectile;
    public GameObject parent;
    public GameObject ancestor; 


    // Use this for initialization
    void Start()
    {
        anim = gameObject.GetComponentInParent<Animator>();
        parentPosition = parent.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(hasFired);
        Debug.Log(DamageInt);
        parentPosition = parent.transform.position;



    }


    public void Fire()
    {

        Debug.Log("I have fired");
        hasFired = true;
        GameObject newProjectile = Instantiate(projectile, parentPosition, ancestor.transform.rotation);

        
    }

    public void AEnd()
    {
        hasFired = false;
        
    }

   

    void ChangeAttack(int modifier)
    {
        DamageInt += modifier;
    }
}
