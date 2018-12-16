using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookCollectible : MonoBehaviour {

    public string weaponName;
    public int inttModifier;
    public ItemScript item;

    // Use this for initialization
    void Start()
    {

        inttModifier = item.intelligence;

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerStats otherStats = other.GetComponent<PlayerStats>();
            if (otherStats.playerClassType.ToString() == "Mage (Classes)")
            {
                other.gameObject.GetComponentInChildren<WeaponSlot>().item = item;
                other.gameObject.GetComponentInChildren<WeaponSlot>().itemImage.sprite = item.spriteImage;
                other.gameObject.BroadcastMessage("ChangeIntelligence", inttModifier, SendMessageOptions.DontRequireReceiver);
                Destroy(gameObject);
            }

            else
            {

            }

        }

    }
}
