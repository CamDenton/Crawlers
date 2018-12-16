using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialsMenu : MonoBehaviour {

    ManagePlayers manager; 
	// Use this for initialization
	void Start () {
		manager = GameObject.Find("PlayersManager").GetComponent<ManagePlayers>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PlayerOneSpecial(int specialNum)
    {
        manager.p1SpecialSlot = specialNum;
    }

    public void PlayerTwoSpecial(int specialNum)
    {
        manager.p2SpecialSlot = specialNum;
    }

    public void PlayerThreeSpecial(int specialNum)
    {
        manager.p3SpecialSlot = specialNum;
    }

    public void PlayerFourSpecial(int specialNum)
    {
        manager.p4SpecialSlot = specialNum;
    }
}
