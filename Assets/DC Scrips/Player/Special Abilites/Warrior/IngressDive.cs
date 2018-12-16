using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngressDive : MonoBehaviour, Special {

    private string specialButton = string.Empty;
    public float impactRadius = 30;
    public float iDamage = 0;
    public float leapForce;
    public float forwardLeapForce; 
    public int cost = 0;
    public float cooldown = 0;
    public bool cDActive = false;
    public bool leaping; 
    Vector3 playerV;
    Vector3 distance;
    Vector3 direction; 
    Vector3 playerV_2;
    public PlayerStats stats;
    public Animator anim;
    public GameObject effect;
    CharacterController playerController;
    PlayerAttack weapon;
    public LayerMask layer;


    public void Activate()
    {
        anim.SetBool("Special 3", true);
        leaping = true; 
        stats.ChangeStamina(cost);
        gameObject.tag = "Untagged";
        cDActive = true;

    }

    public void Land()
    {
        leaping = false; 
        Instantiate(effect, playerV_2, Quaternion.identity);
        Collider[] targets = Physics.OverlapSphere(playerV, impactRadius, layer, QueryTriggerInteraction.UseGlobal);

        for (int i = 0; i < targets.Length; i++)
        {
            Debug.Log(targets[i]);
            if (targets[i].tag == "Enemy")
            {
                
                targets[i].gameObject.BroadcastMessage("Hit", iDamage, SendMessageOptions.DontRequireReceiver);
            }
            

        }
        anim.SetBool("Special 3", false);
        gameObject.tag = "Player";

        StartCoroutine(Ongoing(cooldown));
    }

    public void Cancel()
    {
        throw new System.NotImplementedException();
    }

    public IEnumerator Ongoing(float cooldown)
    {
        yield return new WaitForSeconds(cooldown);
        cDActive = false;
        Debug.Log("Cooldown is" + " " + cDActive);
        StopCoroutine(Ongoing(cooldown));
    }

    // Use this for initialization
    void Start () {
        playerController = gameObject.GetComponent<CharacterController>();
        playerV = transform.position + playerController.center;
        anim = GetComponent<Animator>();
        weapon = gameObject.GetComponentInChildren<PlayerAttack>();
        impactRadius = 20;
        cooldown = 0;
        cost = 60;
        leapForce = 9f;
        forwardLeapForce = 20f; 

        if (gameObject.GetComponent<PlayerMov>())
        {
            specialButton = "SpecialP1";
        }

        else if (gameObject.GetComponent<PlayerMovP2>())
        {
            specialButton = "SpecialP2";
        }
    }
	
	// Update is called once per frame
	void Update () {
        playerV = transform.position + playerController.center;
        playerV_2 = transform.position;
        stats = gameObject.GetComponent<PlayerStats>();
        iDamage = stats.CurrentAttack;

        if(leaping == true)
        {
            playerController.Move((playerController.transform.up * leapForce) * Time.deltaTime);
            playerController.Move((playerController.transform.forward * forwardLeapForce) * Time.deltaTime);
        }

        if (Input.GetButtonDown(specialButton) && stats.CurrentStamina >= cost && cDActive == false)
        {
            Activate();
            
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(playerV, impactRadius);
    }
}
