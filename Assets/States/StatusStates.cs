using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class StatusStates : MonoBehaviour, IStunnable, IKnockable, IExplosive, IBurnable, IPowerable, IPoisonable {
    public bool stunnable;
    public bool flammable;
    public bool knockable;
    public bool buffable;
    public bool poisonable; 
    int pOldAttack;
    int eOldAttack;
    public float poisonCounter;
    public Transform parentObject;
    Vector3 playerPos;
    PlayerStats pStats; 
    EnemyStats eStats; 

    #region Stun System
    public void Stun(float duration)
    {
        if(stunnable == true)
        {
            Debug.Log("Stun Activated");
            if (gameObject.tag == "Player")
            {
                gameObject.GetComponent<CharacterController>().enabled = false;
            }

            else if (gameObject.tag == "Enemy")
            {
                Debug.Log("Enemy is Stunned");
                parentObject.GetComponent<NavMeshAgent>().enabled = false;
            }

            StartCoroutine(StunReturn(duration));
        }

        else
        {

        }
        
    }

    public IEnumerator StunReturn(float durationR)
    {
        Debug.Log("Coroutine Started");
        yield return new WaitForSeconds(durationR);

        if (gameObject.tag == "Player")
        {
            gameObject.GetComponent<CharacterController>().enabled = true;
        }

        else if (gameObject.tag == "Enemy")
        {
            parentObject.GetComponent<NavMeshAgent>().enabled = true;
        }

        StopCoroutine(StunReturn(durationR));

        
    }
    #endregion

    #region Knockback
    public void Knockback(float strength)
    {
        if (gameObject.tag == "Player")
        {
            gameObject.GetComponent<CharacterController>().Move(gameObject.GetComponent<CharacterController>().transform.forward * (-strength + pStats.Weight));
        }

        else if (gameObject.tag == "Enemy")
        {
            parentObject.GetComponent<Rigidbody>().AddRelativeForce(Vector3.back * (strength - eStats.Weight), ForceMode.Impulse);
        }
    }
    #endregion

    #region Explosive

    public void Explode(float strength)
    {
       
        if (gameObject.tag == "Player")
        {
            gameObject.GetComponent<CharacterController>().Move(gameObject.GetComponent<CharacterController>().transform.forward * -strength);
        }

        else if (gameObject.tag == "Enemy")
        {
            Debug.Log("Enemy Should Explode");
            parentObject.GetComponent<Rigidbody>().AddExplosionForce(strength, parentObject.transform.position, 20, 10);
        }
    }

    #endregion


    #region Burn
    public void Burn(float duration)
    {
        Debug.Log("Burn duration is " + duration);
        InvokeRepeating("Burning", 0.1f, duration); 
        //Invoke("Burning", 2); 
    }

    public void Burning()
    {
        int power = 5; 
        if (gameObject.tag == "Enemy")
        {
            Debug.Log("BIG FLAME"); 
            parentObject.GetComponentInChildren<EnemyDamage>().eStats.CurrentHealth = parentObject.GetComponentInChildren<EnemyDamage>().eStats.CurrentHealth - power;
        }
        
    }

    #endregion

    #region Poison

    public void Poison(float duration, int power)
    {
        if(poisonable)
        {
            poisonCounter = duration;
            StartCoroutine(Curing(duration, power));
        }

        else
        {

        }
        
    }

    public IEnumerator Curing(float duration, int powerR)
    {
        for(int i=0; i < poisonCounter; i++)
        {
            if (gameObject.tag == "Enemy")
            {
               gameObject.GetComponent<EnemyDamage>().eStats.CurrentHealth = gameObject.GetComponent<EnemyDamage>().eStats.CurrentHealth - powerR;
            }

            yield return new WaitForSeconds(1);
        }

        StopCoroutine(Curing(duration, powerR));
    }

    #endregion

    #region Power Up

    public void PowerUp(float duration, int power)
    {
        if(gameObject.tag == "Player")
        {
            pOldAttack = pStats.attBuff;
            Debug.Log("Old attack is " + pOldAttack);
            pStats.AttackBuff(power);

        }

        else if(gameObject.tag == "Enemy")
        {
            eOldAttack = eStats.eAttack;
            eStats.eAttack += power;
        }

        StartCoroutine(PowerReturn(duration));
    }

    public IEnumerator PowerReturn(float durationR)
    {
        yield return new WaitForSeconds(durationR);

        if(gameObject.tag == "Player")
        {
            pStats.AttackBuff(pOldAttack);
            Debug.Log("I am the attack from Power Return " + pStats.CurrentAttack);
        }

        else if (gameObject.tag == "Enemy")
        {
            eStats.Attack = eOldAttack;
        }

        StopCoroutine(StunReturn(durationR));
    }

    #endregion

    // Use this for initialization
    void Start () {
        if (gameObject.tag == "Enemy")
        {
            eStats = gameObject.GetComponentInParent<EnemyStats>();
        }

        if(gameObject.tag == "Player")
        {
            pStats = gameObject.GetComponent<PlayerStats>();
        }
         
    }
	
	// Update is called once per frame
	void Update () {
        parentObject = gameObject.transform.parent;
        
    }

}
