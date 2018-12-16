using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour {

    public EnemyStats eStats; 
    public int enemyDamage = 0;
    CharacterController controller;
   

    // Use this for initialization
    void Start()
    {
        eStats = gameObject.GetComponent<EnemyStats>();
        controller = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        enemyDamage = eStats.Attack;
    }

    void OnCollisionEnter(Collision hit)
    {
        
        if (hit.gameObject.tag == "Player")
        {
            hit.gameObject.SendMessageUpwards("Hit", enemyDamage, SendMessageOptions.DontRequireReceiver);
            Debug.Log("Hit");

           
            
        }

    }


     
}
