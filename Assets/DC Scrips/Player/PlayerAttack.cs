using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class PlayerAttack : MonoBehaviour {
    public int AttackInt;
    Animator anim;
   public bool hasHit = false;
    public string attackButton = "FireP1";
    public PlayerStats stats;
    public string currentEffect = null; 
    public float effectDuration;
    public float effectStrength;
    public int effectDamage; 
    public AudioSource swingSound; 
   
	// Use this for initialization
	void Start () {
        anim = gameObject.GetComponentInParent<Animator>();
        stats = gameObject.GetComponentInParent<PlayerStats>();
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(hasHit);
        Debug.Log(AttackInt);
        AttackInt = stats.CurrentAttack;
        

    }


    public void Hit()
    {

        swingSound.Play();
        hasHit = true;
        Debug.Log("hasHit = " + hasHit);

    }

   public void AEnd()
    {
        hasHit = false;
        Debug.Log("hasHit = " + hasHit);
    }

    public void ChangeEffect(string effect)
    {
        currentEffect = effect; 
    }

    public void ChangeDuration(float duration)
    {
        effectDuration = duration;
    }

    public void ChangeEffectStrength(float strength)
    {
        effectStrength = strength;
    }

    public void ChangeEffectDamage(int damamge)
    {
        effectDamage = damamge;
    }

    void OnTriggerEnter(Collider coll)
    {
        Debug.Log(coll + " " + coll.tag);

        if (coll.gameObject.tag == "Enemy" && hasHit == true)


        {
            
            coll.gameObject.SendMessage("Hit", AttackInt, SendMessageOptions.DontRequireReceiver);

            Debug.Log(currentEffect);
            switch (currentEffect)
            {
                case "Stun":
                    coll.gameObject.SendMessage("Stun", effectDuration, SendMessageOptions.DontRequireReceiver);
                    break;

                case "Knockback":
                    coll.gameObject.SendMessage("Knockback", effectStrength, SendMessageOptions.DontRequireReceiver);
                    break;

                case "Burn":
                    coll.gameObject.SendMessage("Burn", effectDuration, SendMessageOptions.DontRequireReceiver);
                    break;

                case "Poison":
                    coll.gameObject.GetComponent<StatusStates>().Poison(effectDuration, effectDamage);
                    break;
            }

            Debug.Log("Trigger Hit");
            AEnd();

        }
            

    }

}


