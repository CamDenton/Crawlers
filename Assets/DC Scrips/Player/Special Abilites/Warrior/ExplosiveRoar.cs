using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveRoar : MonoBehaviour, Special
{
    private string specialButton = string.Empty;
    string currentEffect;
    public float effectDuration;
    float effectStrength; 
    public float roarRadius = 0;
    public float strength = 0;
    public int cost = 0;
    public float cooldown = 0;
    public bool cDActive = false;
    Vector3 playerV;
    Vector3 playerV_2;
    Vector3 direction;
    PlayerAttack weapon;
    CharacterController playerController;
    public LayerMask layer;
    public GameObject currentHit;
    public PlayerStats stats;
    public Animator anim;
    public GameObject effect; 


    public void Activate()
    {
        Debug.Log("Activate has happened");
        Instantiate(effect, playerV_2, Quaternion.identity);
        Collider[] targets = Physics.OverlapSphere(playerV, roarRadius, layer, QueryTriggerInteraction.UseGlobal);
        stats.ChangeStamina(cost);

        for(int i =0; i < targets.Length; i++)
        {
            targets[i].gameObject.BroadcastMessage("Knockback", strength, SendMessageOptions.DontRequireReceiver);

            switch (currentEffect)
            {
                case "Stun":
                    targets[i].gameObject.BroadcastMessage("Stun", effectDuration, SendMessageOptions.DontRequireReceiver);
                    break;

                case "Burn":
                    targets[i].gameObject.BroadcastMessage("Burn", effectDuration, SendMessageOptions.DontRequireReceiver);
                    break;
            }
        }
        cDActive = true;
        anim.SetBool("Special", false);
        StartCoroutine(Ongoing(cooldown));
        
    }

    public void Cancel()
    {
       
    }

    public IEnumerator Ongoing(float cooldown)
    {
        yield return new WaitForSeconds(cooldown);
        cDActive = false;
        Debug.Log("Cooldown is" + " " + cDActive);
        StopCoroutine(Ongoing(cooldown));
    }

    void Start()
    {
        playerController = gameObject.GetComponent<CharacterController>();
        playerV = transform.position + playerController.center;
        anim = GetComponent<Animator>();
        weapon = gameObject.GetComponentInChildren<PlayerAttack>(); 
        if (gameObject.GetComponent<PlayerMov>())
        {
            specialButton = "SpecialP1";
        }

        else if(gameObject.GetComponent<PlayerMovP2>())
        {
            specialButton = "SpecialP2"; 
        }

        
    }

    void Update()
    {
        playerV = transform.position + playerController.center;
        playerV_2 = transform.position; 
        direction = transform.forward;
        stats = gameObject.GetComponent<PlayerStats>();
        currentEffect = weapon.currentEffect;
        effectDuration = weapon.effectDuration;
        effectStrength = weapon.effectStrength;
        strength = stats.CurrentAttack; 

        if (Input.GetButtonDown(specialButton) && stats.CurrentStamina >= cost && cDActive == false)
        {
            anim.SetBool("Special", true);
            
        }

        else
        {

        }
    }

}
