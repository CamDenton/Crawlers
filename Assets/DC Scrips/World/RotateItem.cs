using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateItem : MonoBehaviour {
    GameObject rotatingOBJ;
    float rotationRate;
    Vector3 direction = new Vector3(0, 0, 1);
	// Use this for initialization
	void Start () {
        rotatingOBJ = gameObject;
        rotationRate = Time.deltaTime * 10;
	}
	
	// Update is called once per frame
	void Update () {
        rotatingOBJ.transform.Rotate(direction * rotationRate);
	}
}
