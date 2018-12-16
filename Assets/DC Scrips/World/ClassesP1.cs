using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClassesP1 : MonoBehaviour {

    public GameObject warriorP1;
    public GameObject mageP1;
    public GameObject rogueP1;
    public GameObject rangerP1;
    ManagePlayers manager;
    public Canvas p1WarriorSpec;
    public Canvas p1ClassesCanv; 

	// Use this for initialization
	void Start () {
        manager = GameObject.Find("PlayersManager").GetComponent<ManagePlayers>();
        p1WarriorSpec.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void WarriorSelect()
    {
        manager.playerOneClass = warriorP1;
        p1ClassesCanv.enabled = false;
        p1WarriorSpec.enabled = true;
    }

    public void MageSelect()
    {
        manager.playerOneClass = mageP1;

    }

    public void RogueSelect()
    {
        manager.playerOneClass = rogueP1;

    }

    public void RangerSelect()
    {
        manager.playerOneClass = rangerP1;

    }
}
