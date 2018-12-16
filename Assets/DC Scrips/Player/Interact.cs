using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour {
    Vector3 playerCenter;
    public float radius;
    string iButton; 
	// Use this for initialization
	void Start () {
        radius = 10; 
        if (gameObject.GetComponent<PlayerMov>())
        {
            iButton = "P1Interact";
        }

        else if(gameObject.GetComponent<PlayerMovP2>())
        {
            iButton = "P2Interact";
        }
	}
	
	// Update is called once per frame
	void Update () {
        playerCenter = gameObject.transform.position; 
        if (Input.GetButtonDown(iButton))
        {
            Interaction();
        }
	}

    public void Interaction()
    {

        Collider[] hits = Physics.OverlapSphere(playerCenter, radius);
        for (int i = 0; i < hits.Length; i++)
        {
            hits[i].gameObject.BroadcastMessage("Interact", SendMessageOptions.DontRequireReceiver);
        }
    }
}
