using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour {
    GameObject managerObj; 

	// Use this for initialization
	void Start () {
         
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void Awake()
    {
        managerObj = GameObject.Find("PlayersManager");
        Destroy(managerObj); 
    }
}
