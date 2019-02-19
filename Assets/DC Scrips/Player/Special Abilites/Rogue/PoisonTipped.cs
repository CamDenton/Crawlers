using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonTipped : MonoBehaviour, Special {

    private string specialButton = string.Empty;
    public int poisonStr;
    public float effectDuration;
    public int cost = 0;
    public float cooldown = 0;
    public bool cDActive = false;
    Vector3 playerV;
    Vector3 playerV_2;
    CharacterController playerController;
    public PlayerStats stats;
    public GameObject effect;
    public Animator anim;
    PoisonTipped pTipAbility; 

    public void Activate()
    {
        if (pTipAbility.enabled == true)
        {
            Instantiate(effect, playerV_2, Quaternion.identity);
            stats.ChangeStamina(cost);

            gameObject.GetComponentInChildren<PlayerAttack>().ChangeEffect("Poison");
            gameObject.GetComponentInChildren<PlayerAttack>().ChangeEffectDamage(poisonStr);
            gameObject.GetComponentInChildren<PlayerAttack>().ChangeDuration(effectDuration);

            anim.SetBool("Special 2", false);
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
        effectDuration = 5;
        playerController = gameObject.GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        pTipAbility = GetComponent<PoisonTipped>();

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
        poisonStr = stats.CurrentAttack / 4;

        if (Input.GetButtonDown(specialButton) && stats.CurrentStamina >= cost && cDActive == false)
        {
            anim.SetBool("Special 2", true);
            //Activate();

        }
    }
}
