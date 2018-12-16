using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ItemScript : ScriptableObject {

    public Sprite spriteImage;
    public GameObject item;
    public int attack;
    public int intelligence; 
    public string ItemType = string.Empty;
    public bool stun;
    public bool knockback;
    public bool burn; 
    public float effectDuration;
    public float effectStrength;
	
}

