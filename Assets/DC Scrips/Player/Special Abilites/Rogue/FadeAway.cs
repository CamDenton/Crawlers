using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeAway : MonoBehaviour, Special {


    private string specialButton = string.Empty;
    public int cost = 0;
    public float cooldown = 0;
    public bool cDActive = false;
    public PlayerStats stats;
    Vector3 playerV;
    public Animator anim;
    public GameObject playerObject;
    public GameObject effect;
    FadeAway fade;

    public void Activate()
    {
        if (fade.enabled == true)
        {

       
        Instantiate(effect, playerV, Quaternion.identity);
        stats.ChangeStamina(cost);
        playerObject.tag = "Untagged";
        cDActive = true;
        anim.SetBool("Special", false);
        StartCoroutine(Ongoing(cooldown));

        }

    }

    public void Cancel()
    {
        playerObject.tag = "Player";
        cDActive = false;
    }

    public IEnumerator Ongoing(float cooldown)
    {
        if (Input.GetButtonDown(specialButton))
        {
            Cancel();
        }

        yield return new WaitForSeconds(cooldown);
        playerObject.tag = "Player";
        cDActive = false;
        Debug.Log("Cooldown is" + " " + cDActive);
        StopCoroutine(Ongoing(cooldown));
    }

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        playerObject = gameObject;
        fade = GetComponent<FadeAway>();

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
        stats = gameObject.GetComponent<PlayerStats>();
        playerV = transform.position;

        if (Input.GetButtonDown(specialButton) && stats.CurrentStamina >= cost && cDActive == false)
        {
            anim.SetBool("Special", true);

        }

        else
        {

        }
    }
}
