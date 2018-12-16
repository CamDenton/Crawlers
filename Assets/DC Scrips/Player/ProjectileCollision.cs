using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileCollision : MonoBehaviour {

    public PlayerStats stats;
    public string parentName;
    GameObject parentObj;
    int damage;
    Rigidbody projectileBody;
    public int velocity;
    public int speed;


	// Use this for initialization
	void Start () {
        projectileBody = GetComponent<Rigidbody>();
        parentObj = GameObject.Find(parentName);
        stats = parentObj.GetComponent<PlayerStats>();
        projectileBody.AddRelativeForce(Vector3.forward * velocity);

    }
	
	// Update is called once per frame
	void Update () {
        projectileBody.AddRelativeForce(Vector3.forward * velocity);
        damage = stats.CurrentIntelligence;
        Debug.Log(damage + "The Spell's Damage");
    }


    void OnTriggerEnter(Collider coll)
    {

        if (coll.gameObject.tag == "Enemy")


        {

            coll.gameObject.SendMessageUpwards("Hit", damage, SendMessageOptions.DontRequireReceiver);
            Debug.Log("Trigger Hit");
            Destroy(this.gameObject);
            

        }

        else
        {
            Debug.Log("Collided");
            Destroy(this.gameObject);
        }


    }
}
