using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonTipped : MonoBehaviour, Special {

    private string specialButton = string.Empty;
    public int poisonStr;
    public float effectuation; 

    public void Activate()
    {
        throw new System.NotImplementedException();
    }

    public void Cancel()
    {
        throw new System.NotImplementedException();
    }

    public IEnumerator Ongoing(float cooldown)
    {
        throw new System.NotImplementedException();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
