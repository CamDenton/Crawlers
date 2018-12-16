using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class MoraleBar : MonoBehaviour {
    public int currentMorale = 0;
    public int maxMorale = 0;
    public int updatdCMorale;
    public int updatedMMorale;
    public Slider moraleBar; 
    public List<GameObject> playerList;
 
   

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        playerList = new List<GameObject>(GameObject.FindGameObjectsWithTag("Player"));

        UpdateCurrentMorale();

        UpdateMaxMorale();

        moraleBar.value = updatdCMorale;
        moraleBar.maxValue = updatedMMorale;

        Debug.Log("Current Morale is " + updatdCMorale);
        Debug.Log("Max Morale is " + updatedMMorale); 
    }

    void UpdateCurrentMorale()
    {
        foreach (GameObject player in playerList)
        {
            currentMorale = player.GetComponent<PlayerStats>().CurrentHealth + currentMorale;
        }
        updatdCMorale = currentMorale;
        currentMorale = 0;
    }

    void UpdateMaxMorale()
    {
        foreach (GameObject player in playerList)
        {
            maxMorale = player.GetComponent<PlayerStats>().MaxHealth + maxMorale;
        }

        updatedMMorale = maxMorale;
        maxMorale = 0; 
    }
}
