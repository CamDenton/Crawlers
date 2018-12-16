using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveBreak : MonoBehaviour, Special {

    public string specialButton = string.Empty;
    public int cost = 50;
    public GameObject waveObj;
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


    public void Activate()
    {
        newProjectile = Instantiate(waveObj, parentPosition, instaPoint.transform.rotation);
        newProjectile.GetComponentInChildren<WBProjectile>().damage = fullDamage;
        anim.SetBool("Special 2", false);
        cDActive = true;
        StartCoroutine(Ongoing(cDown));
    }

    public void Cancel()
    {
       
    }

    public IEnumerator Ongoing(float cooldown)
    {
        yield return new WaitForSeconds(cooldown);
        cDActive = false;
        Debug.Log("Cooldown is" + " " + cDActive);
        Destroy(newProjectile);
        StopCoroutine(Ongoing(cooldown));
    }

    // Use this for initialization
    void Start () {
        
        playerControl = gameObject.GetComponent<CharacterController>();
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
        parentPosition = instaPoint.transform.position;
        stats = gameObject.GetComponent<PlayerStats>();
        fullDamage = baseDamage + (stats.CurrentAttack); 

        if (Input.GetButtonDown(specialButton) && stats.CurrentStamina >= cost && cDActive == false)
        {
            anim.SetBool("Special 2", true);
        }

        else
        {

        }
    }
}
