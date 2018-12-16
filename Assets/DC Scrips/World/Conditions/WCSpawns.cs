using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WCSpawns : MonoBehaviour {

    public List<GameObject> listOfSpawns;
    public bool isComplete = false; 
 
	// Use this for initialization
	void Start () {
		listOfSpawns = new List<GameObject>(GameObject.FindGameObjectsWithTag("Spawns"));
    }
	
	// Update is called once per frame
	void Update () {
        listOfSpawns = new List<GameObject>(GameObject.FindGameObjectsWithTag("Spawns"));
        Debug.Log(listOfSpawns.Count + " This is the WC list"); 
        if (listOfSpawns.Count == 0)
        {
            isComplete = true; 
        }
	}
}
