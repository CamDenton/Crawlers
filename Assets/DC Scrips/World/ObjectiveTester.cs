using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveTester : MonoBehaviour {
    public List<GameObject> listOfSpawns;
    int listCount;
    GameObject item;
    // Use this for initialization
    void Start()
    {
        listOfSpawns = new List<GameObject>(GameObject.FindGameObjectsWithTag("Spawns"));
    }

    // Update is called once per frame
    void Update()
    {
        listOfSpawns = new List<GameObject>(GameObject.FindGameObjectsWithTag("Spawns"));
        listCount = listOfSpawns.Count;
        item = listOfSpawns[listCount - 1];
        Debug.Log(listCount + " " + "This is the List Count");
        
    }

    private void FixedUpdate()
    {
        Invoke("RemoveSpawn", 1);
    }

    void RemoveSpawn()
    {
        GameObject.Destroy(item);
        Debug.Log("Removing item");
    }
}

