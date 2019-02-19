using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreadTrail : MonoBehaviour, Special {

    public string specialButton = string.Empty;
    public int cost = 50;
    public GameObject beaconObj; 
    GameObject newBeacon;
    public List<GameObject> beaconCount;
    public float cDown = 3;
    public bool cDActive = false;
    Vector3 parentPosition;
    public PlayerStats stats;
    public Animator anim;
    public GameObject instaPoint;
    int beaconLimit; 

    public void Activate()
    {
        if(beaconCount.Count < beaconLimit)
        {
            newBeacon = Instantiate(beaconObj, parentPosition, instaPoint.transform.rotation);
            anim.SetBool("Special 4", false);
            cDActive = true;
            StartCoroutine(Ongoing(cDown));
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
        //Destroy(newProjectile);
        StopCoroutine(Ongoing(cooldown));
    }

    // Use this for initialization
    void Start () {
        beaconLimit = 3;
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
        beaconCount = new List<GameObject>(GameObject.FindGameObjectsWithTag("beacon"));

        if (Input.GetButtonDown(specialButton) && stats.CurrentStamina >= cost && cDActive == false)
        {
            anim.SetBool("Special 4", true);
            //Activate();
        }
    }
}
