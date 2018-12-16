using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour {
    public EnemyType type;
    public string eName;
    protected int eCurrentHealth;
    protected int eMaxhealth; 
    protected int eCurrentStamina;
    protected int eMaxStamina;
    protected int eCurrentMana;
    protected int eMaxMana; 
    public int eAttack;
    protected int eArmor;
    protected int eIntelligence;
    protected int eWeight;
    protected int eSpeed;

    // Use this for initialization
    void Start () {
        eName = type.enemyName;
        eMaxhealth = type.enemyHealth;
        eMaxStamina = type.enemyStamina;
        eMaxMana = type.enemyMana;
        eAttack = type.enemyAttack;
        eArmor = type.enemyArmor;
        eIntelligence = type.enemyIntelligence;
        eWeight = type.enemyWeight;
        eSpeed = type.enemySpeed; 

        eCurrentHealth = eMaxhealth;
        eCurrentStamina = eMaxStamina;
        eCurrentMana = eMaxMana; 
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    public int CurrentHealth
    {
        get { return eCurrentHealth; }
        set { eCurrentHealth = value;  }
    }

    public int MaxHealth
    {
        get { return eMaxhealth; }
        set { eMaxhealth = value; }
    }

    public int CurrentStamina
    {
        get { return eCurrentStamina; }
        set { eCurrentStamina = value; }
    }

    public int MaxStamina
    {
        get { return eMaxStamina; }
        set { eMaxStamina = value; }
    }

    public int CurrentMana
    {
        get { return eCurrentMana; }
        set { eCurrentMana = value; }
    }

    public int MaxMana
    {
        get { return eMaxMana; }
        set { eMaxMana = value; }
    }

    public int Attack
    {
        get { return eAttack; }
        set { eAttack = value; }
    }

    public int Armor
    {
        get { return eArmor; }
        set { eArmor = value; }
    }

    public int Intelligence
    {
        get { return eIntelligence; }
        set { eIntelligence = value; }
    }

    public int Weight
    {
        get { return eWeight; }
        set { eWeight = value; }
    }

    public int Speed
    {
        get { return eSpeed; }
        set { eSpeed = value; }
    }

}
