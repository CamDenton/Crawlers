using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirageBomb : MonoBehaviour, Special {

    public string specialButton = string.Empty;
    public int cost = 50;
    public GameObject bombObj;
    public int baseDamage = 10;
    public int fullDamage;
    public float cDown = 3;
    public bool cDActive = false;
    Vector3 parentPosition;
    public GameObject instaPoint;
    public PlayerStats stats;
    public Vector3 instOffset;
    CharacterController playerControl;
    GameObject newProjectile;
    public Animator anim;
    PlayerAttack pAttack; 

    public string currentEffect = null;
    public float effectDuration;
    public float effectStrength;
    public int effectDamage;



    public void Activate()
    {
        newProjectile = Instantiate(bombObj, parentPosition, instaPoint.transform.rotation);
        newProjectile.GetComponentInChildren<MBProjectile>().damage = fullDamage;
        newProjectile.GetComponentInChildren<MBProjectile>().currentEffect = currentEffect;
        newProjectile.GetComponentInChildren<MBProjectile>().effectDuration = effectDuration;
        newProjectile.GetComponentInChildren<MBProjectile>().effectStrength = effectStrength;
        newProjectile.GetComponentInChildren<MBProjectile>().effectDamage = effectDamage; 
        anim.SetBool("Special 3", false);
        cDActive = true;
        StartCoroutine(Ongoing(cDown));
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
        //Destroy(newProjectile);
        StopCoroutine(Ongoing(cooldown));
    }

    // Use this for initialization
    void Start () {

        playerControl = gameObject.GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        pAttack = GetComponentInChildren<PlayerAttack>();
        
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
        parentPosition = instaPoint.transform.position;
        stats = gameObject.GetComponent<PlayerStats>();
        fullDamage = baseDamage + (stats.CurrentAttack / 2);
        currentEffect = pAttack.currentEffect;
        effectDuration = pAttack.effectDuration;
        effectStrength = pAttack.effectStrength;
        effectDamage = pAttack.effectDamage; 

        if (Input.GetButtonDown(specialButton) && stats.CurrentStamina >= cost && cDActive == false)
        {
            anim.SetBool("Special 3", true);
            //Activate();
        }

        else
        {
            
        }
    }

}
