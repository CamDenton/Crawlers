using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSlot : MonoBehaviour {
    public ItemScript item;
    public Image itemImage;

    private void Update()
    {
        
    }

    public void addWeapon(ItemScript addedItem)
    {

        if(item == null)
        {
            item = addedItem;
            itemImage.sprite = addedItem.spriteImage;
            itemImage.enabled = true;
        }

        else
        {
            removeWeapon();
            item = addedItem;
            itemImage.sprite = addedItem.spriteImage;
            itemImage.enabled = true;

        }
    }

    public void removeWeapon()
    {
        item = null;
        itemImage.sprite = null;
        itemImage.enabled = false;
    }
	
}
