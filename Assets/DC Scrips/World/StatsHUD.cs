using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsHUD : MonoBehaviour
{
    public GameObject player;
   PlayerStats stats;
    public Text attackStat;
    public Text intellStat;
    public Text armorStat;
    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        stats = player.GetComponent<PlayerStats>();
        attackStat.text = "Attack: " + stats.CurrentAttack.ToString();
        intellStat.text = "Intelligence: " + stats.CurrentIntelligence.ToString();
        armorStat.text = "Armor: " + stats.Armor.ToString();
    }
}