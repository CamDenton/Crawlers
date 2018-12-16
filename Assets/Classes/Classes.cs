using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Classes : ScriptableObject {
    public string playerName = string.Empty;
    public string className;
    public int currentHealth = 0;
    public int maxHealth = 0;
    public int armor = 0;
    public int currentStamina = 0;
    public int maxStamina = 0;
    public int currentMana = 0;
    public int maxMana = 0;
    public int attack = 0;
    public int intelligence = 0;
    public int weight = 0;
    public float speed = 0;


    public string PlayerName
    {
        get { return playerName; }
        set { playerName = value; }
    }

    public string ClassName
    {
        get { return className ; }

    }

    public int CurrentHealth
    {
        get { return currentHealth; }
        set { currentHealth = value; }
    }

    public int MaxHealth
    {
        get { return maxHealth; }
        set { maxHealth = value; }
    }

    public int Armor
    {
        get { return armor; }
        set { armor = 0; }
    }

    public int CurrentStamina
    {
        get { return currentStamina; }
        set { currentStamina = value; }
    }

    public int MaxStamina
    {
        get { return maxStamina; }
        set { maxStamina = value; }
    }

    public int CurrentMana
    {
        get { return currentMana; }
        set { currentMana = value; }
    }

    public int MaxMana
    {
        get { return maxMana; }
        set { maxMana = value; }
    }

    public int Attack
    {
        get { return attack; }
        set { attack = value; }
    }

    public int Intelligence
    {
        get { return intelligence; }
        set { intelligence = value; }
    }

    public int Weight
    {
        get { return weight; }
        set { weight = value; }
    }

    public float Speed
    {
        get { return speed; }
        set { speed = value; }
    }


}
