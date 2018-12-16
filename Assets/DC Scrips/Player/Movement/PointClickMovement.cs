using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PointClickMovement : MonoBehaviour {

    NavMeshAgent agent;
    LayerMask worldLayer;
    LayerMask enemyLayer;
    
    // Use this for initialization
    void Start () {
        agent = GetComponent<NavMeshAgent>();
        worldLayer = LayerMask.GetMask("World");
        enemyLayer = LayerMask.GetMask("Enemy");
        
      

	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            RaycastHit hit;

            if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100, worldLayer))
            {
                agent.destination = hit.point;
            }

            else if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100, enemyLayer))
            {
                agent.destination = hit.point;

                agent.stoppingDistance = 5;
            }
        }
		
	}
}
