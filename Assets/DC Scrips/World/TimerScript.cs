using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour {
    float secTime;
    float minuTime;
    public Text timeText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        secTime += Time.deltaTime;

        if(secTime >= 60)
        {
            minuTime++;
            secTime = 0;
        }

        timeText.text = (minuTime + ":" + secTime);
	}
}
