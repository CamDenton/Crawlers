using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordCollectible : MonoBehaviour {
    public string weaponName;
    public int attackModifier;
    public ItemScript item;
    public string effectType = null;
    public float effectDuration;
    public float effStrength; 
   
	// Use this for initialization
	void Start () {

        attackModifier = item.attack;
        effectDuration = item.effectDuration;
        effStrength = item.effectStrength;

        if (item.stun == true)
        {
            effectType = "Stun";
        }

        if (item.knockback == true)
        {
            effectType = "Knockback";
        }

        if (item.burn == true)
        {
            effectType = "Burn"; 
        }
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            PlayerStats otherStats = other.GetComponent<PlayerStats>();
            if (otherStats.playerClassType.ToString() == "Warrior (Classes)")
            {
                //other.gameObject.GetComponentInChildren<WeaponSlot>().item = item;
                //other.gameObject.GetComponentInChildren<WeaponSlot>().itemImage.sprite = item.spriteImage;
                other.gameObject.BroadcastMessage("ChangeAttack", attackModifier, SendMessageOptions.DontRequireReceiver);

                if (effectType != null)
                {
                    other.gameObject.BroadcastMessage("ChangeEffect", effectType, SendMessageOptions.DontRequireReceiver);
                    other.gameObject.BroadcastMessage("ChangeEffectStrength", effStrength, SendMessageOptions.DontRequireReceiver);
                    other.gameObject.BroadcastMessage("ChangeDuration", effectDuration, SendMessageOptions.DontRequireReceiver);

                }
                
                Destroy(gameObject);
            }

            else
            {

            }

        }

    }
}
