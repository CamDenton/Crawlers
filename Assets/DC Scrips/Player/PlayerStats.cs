using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

    public Classes playerClassType;
    public string playerName = string.Empty;
    public string playerClass = string.Empty;
    protected int playerCurrentHealth;
    protected int playerMaxHealth = 0;
    protected int playerArmor = 0;
    protected int playerCurrentStamina = 0;
    protected int playerMaxStamina = 0;
    protected int playerCurrentMana = 0;
    protected int playerMaxMana = 0;
    protected int playerBaseIntelligence = 0;
    protected int playerCurrentIntelligence = 0;
    protected int playerBaseAttack = 0;
    protected int playerCurrentAttack = 0;
    public int weapAtt;
    public int weapIntt;
    public int armorInt;
    public int weightInt;
    public int attBuff = 0; 
    protected int playerWeight = 0;
    public float playerSpeed = 0;



    void Start()
    {
        playerMaxHealth = playerClassType.MaxHealth;
        playerCurrentHealth = playerMaxHealth;
        playerCurrentStamina = playerMaxStamina;
        playerMaxStamina = playerClassType.MaxStamina;
        playerCurrentMana = playerMaxMana;
        playerMaxMana = playerClassType.MaxMana;
        playerBaseIntelligence = playerClassType.Intelligence;
        playerCurrentIntelligence = playerBaseIntelligence + weapIntt;
        playerBaseAttack = playerClassType.Attack;
        playerCurrentAttack = playerBaseAttack + weapAtt;
        playerWeight = playerClassType.Weight;
        playerSpeed = playerClassType.Speed;

    }

    private void Update()
    {
        playerCurrentIntelligence = playerBaseIntelligence + weapIntt;
        playerCurrentAttack = playerBaseAttack + weapAtt + attBuff;
        playerArmor = playerClassType.Armor + armorInt;
        playerWeight = playerClassType.Weight + weightInt; 
        

        Debug.Log("PlayerStats speed is " + playerSpeed);
    }

    public string PlayerName
    {
        get { return playerName; }
        set { playerName = value; }
    }

    public string ClassName
    {
        get { return playerClassType.ClassName; }

    }



    public int CurrentHealth
    {
        get { return playerCurrentHealth; }
        set { playerCurrentHealth = value; }
    }

    public int MaxHealth
    {
        get { return playerMaxHealth; }
        set { playerMaxHealth = value; }
    }

    public int Armor
    {
        get { return playerArmor; }
        set { playerArmor = value; }
    }

    public int CurrentStamina
    {
        get { return playerCurrentStamina; }
        set { playerCurrentStamina = value; }
    }

    public int MaxStamina
    {
        get { return playerMaxStamina; }
        set { playerMaxStamina = value; }
    }

    public int CurrentMana
    {
        get { return playerCurrentMana; }
        set { playerCurrentMana = value; }
    }

    public int MaxMana
    {
        get { return playerMaxMana; }
        set { playerMaxMana = value; }
    }

    public int BaseIntelligence
    {
        get { return playerBaseIntelligence; }
        set { playerBaseIntelligence = value; }
    }

    public int CurrentIntelligence
    {
        get { return playerCurrentIntelligence; }
        set { playerCurrentIntelligence = value; }
    }

    public int BaseAttack
    {
        get { return playerBaseAttack; }
        set { playerBaseAttack = value; }
    }

    public int CurrentAttack
    {
        get { return playerCurrentAttack;  }
        set { playerCurrentAttack = value; }
    }

    public int Weight
    {
        get { return playerWeight; }
        set { playerWeight = value; }
    }

    public float Speed
    {
        get { return playerSpeed; }
        set { playerSpeed = value; }
    }

    public void ChangeAttack(int modifier)
    {
        weapAtt = modifier;
    }

    public void AttackBuff(int buff)
    {
        attBuff = buff;
    }

    public void ChangeIntelligence(int modifier)
    {
        weapIntt = modifier;
    }

    public void ChangeStamina(int modifier)
    {
        CurrentStamina = CurrentStamina - modifier; 
    }

    public void ChangeArmor(int modifier)
    {
        armorInt = modifier;
    }

    public void ChangeWeight(int modifier)
    {
        weightInt = modifier; 
    }

}

















