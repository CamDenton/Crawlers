using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerSelectMenu : MonoBehaviour {
    public GameObject manager;
    ManagePlayers managerScript;
    public Canvas pOneClasses;
    public Canvas pTwoClasses;
    public Canvas pThreeClasses;
    public Canvas pFourClasses;
 
    // Use this for initialization

    private void Awake()
    {
        manager = GameObject.Find("PlayersManager");
        managerScript = manager.GetComponent<ManagePlayers>();
        pOneClasses.enabled = false;
        pTwoClasses.enabled = false;
        pThreeClasses.enabled = false;
        pFourClasses.enabled = false;
    }

    void Start () {
        
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SinglePlayer()
    {
        managerScript.singleSelected = true;
        managerScript.twoSelected = false;
        managerScript.threeSelected = false;
        managerScript.fourSelected = false;
        pOneClasses.enabled = true;
        
    }

    public void TwoPlayer()
    {
        managerScript.singleSelected = false;
        managerScript.twoSelected = true;
        managerScript.threeSelected = false;
        managerScript.fourSelected = false;
        pOneClasses.enabled = true;
        pTwoClasses.enabled = true;
        pThreeClasses.enabled = false;
        pFourClasses.enabled = false;
    }
    public void ThreePlayer()
    {
        managerScript.singleSelected = false;
        managerScript.twoSelected = false;
        managerScript.threeSelected = true;
        managerScript.fourSelected = false;
        pOneClasses.enabled = true;
        pTwoClasses.enabled = true;
        pThreeClasses.enabled = true;
        pFourClasses.enabled = false;
    }

    public void FourPlayer()
    {
        managerScript.singleSelected = false;
        managerScript.twoSelected = false;
        managerScript.threeSelected = false;
        managerScript.fourSelected = true;
        pOneClasses.enabled = true;
        pTwoClasses.enabled = true;
        pThreeClasses.enabled = true;
        pFourClasses.enabled = true;
    }

    public void Begin()
    {
        
        SceneManager.LoadSceneAsync(Random.Range(2, 4), LoadSceneMode.Single);
    }
}
