using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorCollect : MonoBehaviour {

    public string armorName;
    public int armorModifier;
    public int armorWeight; 
    public ArmorBase armor; 
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        armorName = armor.armorName;
        armorModifier = armor.armorRating;
        armorWeight = armor.armorWeight;
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerStats otherStats = other.GetComponent<PlayerStats>();
            if (otherStats.playerClassType.ToString() == "Warrior (Classes)")
            {
                //other.gameObject.GetComponentInChildren<WeaponSlot>().item = item;
                //other.gameObject.GetComponentInChildren<WeaponSlot>().itemImage.sprite = item.spriteImage;
                other.gameObject.BroadcastMessage("ChangeArmor", armorModifier, SendMessageOptions.DontRequireReceiver);
                other.gameObject.BroadcastMessage("ChangeWeight", armorWeight, SendMessageOptions.DontRequireReceiver);

                Destroy(gameObject);
            }

            else
            {

            }

        }

    }
}
