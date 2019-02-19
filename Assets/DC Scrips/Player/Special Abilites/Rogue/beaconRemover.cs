using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beaconRemover : MonoBehaviour {

    public int removalTime;
	// Use this for initialization
	void Start () {
    removalTime = 30;
    Invoke("BeaconRemoval", removalTime);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void BeaconRemoval()
    {
        Destroy(gameObject);
    }
}
