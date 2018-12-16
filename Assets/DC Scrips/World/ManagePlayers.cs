using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagePlayers : MonoBehaviour {

    public bool singleSelected = false;
    public bool twoSelected = false;
    public bool threeSelected = false;
    public bool fourSelected = false;
    public GameObject playerOneClass;
    public GameObject playerTwoClass;
    public GameObject playerThreeClass;
    public GameObject playerFourClass; 
    public GameObject playersMenu;
    public GameObject classesMenu;
    public GameObject p1Hud;
    public GameObject p2Hud;
    public GameObject p3Hud;
    public GameObject p4Hud;
    public int p1SpecialSlot;
    public int p2SpecialSlot;
    public int p3SpecialSlot;
    public int p4SpecialSlot;


    // Use this for initialization
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

  
    
   

    
   
}
