using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDElements : MonoBehaviour {

    public GameObject player;
    public PlayerStats stats;
    public Slider healthBar;
    public Slider staminaBar;
    public Text attackStat;
    public Text intellStat;
    public Text armorStat;
    // Use this for initialization
    void Start () {
        stats = player.GetComponent<PlayerStats>();
	}
	
	// Update is called once per frame
	void Update () {
        healthBar.value = stats.CurrentHealth;
        healthBar.maxValue = stats.MaxHealth;
        staminaBar.value = stats.CurrentStamina;
        staminaBar.maxValue = stats.MaxStamina; 
        attackStat.text = "Attack: " + stats.CurrentAttack.ToString();
        intellStat.text = "Intelligence: " + stats.CurrentIntelligence.ToString();
        armorStat.text = "Armor: " + stats.Armor.ToString();
    }
}
