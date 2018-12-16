using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;


public class EnemyDamage : MonoBehaviour{

    public EnemyStats eStats;
    Rigidbody parentBody;
    public Slider healthBar;
    GameObject thisEnemy;
    NavMeshAgent agent;
    public EnemyMovement eMove;
    public StatusStates stateManager;
    public AudioSource hitSound; 
    
    // Use this for initialization
    void Start () {

        eStats = gameObject.GetComponentInParent<EnemyStats>();
        parentBody = GetComponentInParent<Rigidbody>();
        thisEnemy = gameObject;
        agent = GetComponentInParent<NavMeshAgent>();
        stateManager = GetComponent<StatusStates>();
        hitSound = gameObject.GetComponent<AudioSource>();
        healthBar.maxValue = eStats.MaxHealth;
        
    }
	
	// Update is called once per frame
	void Update () {
        healthBar.value = eStats.CurrentHealth;


        if (eStats.CurrentHealth <= 0)
        {
            SendMessageUpwards("RemoveSpawn", SendMessageOptions.DontRequireReceiver);
            Destroy(transform.parent.gameObject);

        }
    }

    public void Hit(int damage)
    {
        eStats.CurrentHealth = eStats.CurrentHealth - (damage - eStats.Armor);
        parentBody.AddRelativeForce(Vector3.back * 10, ForceMode.Force);
        hitSound.Play();
        agent.Move(agent.transform.forward * -3); 
        Debug.Log("Enemy hit with damage " + damage);

    }

   public void Separate()
    {
        parentBody.AddRelativeForce(Vector3.left * 8, ForceMode.Force);
        agent.Move(agent.transform.right* -8);
    }
}
