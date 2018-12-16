using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour {
    public EnemyStats eStats;
    GameObject player;
    float playerX;
    float playerZ;
    bool playerDetected;
    Vector3 playerPos;
    NavMeshAgent agent;
    CharacterController controller;
    
   
	// Use this for initialization
	void Start () {
        eStats = gameObject.GetComponentInParent<EnemyStats>();
        agent = GetComponentInParent<NavMeshAgent>();
        
        
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        agent.speed = eStats.Speed;
        
		if (playerDetected == false)
        {
            Rest();
        }

        else if (playerDetected == true)
        {
            Approach();
        }

        playerPos = player.transform.position;
        playerX = player.transform.position.x;
        playerZ = player.transform.position.z; 
    }

    void OnTriggerEnter (Collider coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            playerDetected = true;
            player = coll.gameObject;
        }
    }

    void OnTriggerExit (Collider coll)
    {
        playerDetected = false;
    }

    void Approach ()
    {
        //transform.position = Vector3.MoveTowards(transform.position, playerPos, speed * Time.deltaTime);
        transform.LookAt(playerPos);
        agent.destination = playerPos;

        
    }

    void Rest ()
    {
        
    }
}
