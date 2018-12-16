using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WBProjectile : MonoBehaviour {
    public WaveBreak parentWave;
    public string parentName = string.Empty;
    //public GameObject parentObj;
    public int damage;
    public int currentDamage;
    public int waveForce; 
    Rigidbody projectileBody;
    public int velocity;
    public int speed;
    
    // Use this for initialization
    void Start () {
        velocity = 50;
        projectileBody = GetComponentInChildren<Rigidbody>();
        currentDamage = damage;
        projectileBody.AddRelativeForce(transform.TransformDirection(Vector3.forward) * velocity, ForceMode.Impulse);
    }
	
	// Update is called once per frame
	void Update () {
        //projectileBody.AddRelativeForce(transform.TransformDirection(Vector3.forward) * velocity, ForceMode.Acceleration);
        projectileBody.GetComponentInChildren<Rigidbody>().velocity = projectileBody.transform.forward * velocity; 
        Debug.Log(damage + " The Spell's Damage");
        waveForce = currentDamage / 2;
        
    }

    void OnTriggerEnter(Collider coll)
    {

        if (coll.gameObject.tag == "Enemy")


        {

            coll.gameObject.SendMessage("Hit", (currentDamage/ 2), SendMessageOptions.DontRequireReceiver);
            coll.gameObject.SendMessage("Separate", currentDamage, SendMessageOptions.DontRequireReceiver);
            Debug.Log("Trigger Hit with damage " + currentDamage);
            //Destroy(gameObject); 


        }

        else
        {
           
        }


    }
}
