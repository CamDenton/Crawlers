using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassesP2 : MonoBehaviour
{

    public GameObject warriorP2;
    public GameObject mageP2;
    public GameObject rogueP2;
    public GameObject rangerP2;
    ManagePlayers manager;

    // Use this for initialization
    void Start()
    {
        manager = GameObject.Find("PlayersManager").GetComponent<ManagePlayers>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void WarriorSelect()
    {

        manager.playerTwoClass = warriorP2;

    }

    public void MageSelect()
    {

        if (manager.twoSelected)
        {
            manager.playerTwoClass = mageP2;
        }
    }

    public void RogueSelect()
    {


        if (manager.twoSelected)
        {
            manager.playerTwoClass = rogueP2;
        }

    }

    public void RangerSelect()
    {

        if (manager.twoSelected == true)
        {
            manager.playerTwoClass = rangerP2;
        }

    }
}
