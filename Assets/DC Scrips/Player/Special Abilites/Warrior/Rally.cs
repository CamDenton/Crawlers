using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rally : MonoBehaviour, Special {
    private string specialButton = string.Empty;
    public int cost = 0;
    public int rallyPower = 0;
    public float cooldown = 0;
    public float rallyRadius = 0; 
    public bool cDActive = false;
    public float rallyDuration = 0;
    Vector3 playerV;
    Vector3 playerV_2;
    CharacterController playerController;
    StatusStates targetState;
    GameObject currentTarget; 
    public PlayerStats stats;
    public GameObject effect;
    public LayerMask layer;
    public Animator anim;
    public bool isEnabled = false; 

    public void Activate()
    {
        if(isEnabled == true)
        {

        
        Instantiate(effect, playerV_2, Quaternion.identity);
        Collider[] targets = Physics.OverlapSphere(playerV, rallyRadius, layer, QueryTriggerInteraction.UseGlobal);
        stats.ChangeStamina(cost);

        foreach(Collider coll in targets)
        {
            if(coll.gameObject.tag == "Player")
            {
                coll.GetComponent<StatusStates>().PowerUp(rallyDuration, rallyPower);
            }

            else
            {

            }
        }

        cDActive = true;
        anim.SetBool("Special 4", false);
        StartCoroutine(Ongoing(cooldown));
        }
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

        cost = 60;
        cooldown = 10;
        rallyRadius = 30f;
        rallyDuration = 5;
        playerController = gameObject.GetComponent<CharacterController>();
        anim = GetComponent<Animator>();

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

        Debug.Log("Current Attack is " + stats.CurrentAttack);
        rallyPower = stats.CurrentAttack / 2;

        if (Input.GetButtonDown(specialButton) && stats.CurrentStamina >= cost && cDActive == false && isEnabled == true)
        {
            anim.SetBool("Special 4", true);
            //Activate();

        }
    }
}
