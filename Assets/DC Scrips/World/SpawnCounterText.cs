using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnCounterText : MonoBehaviour {
    public GameObject scnManager;
    WCSpawns spawns;
    int spawnNumber;
    public Text spawnText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        spawns = scnManager.GetComponent<WCSpawns>();
        spawnNumber = spawns.listOfSpawns.Count;
        spawnText.text = "Hordes Left: " + spawnNumber.ToString();
	}
}
