using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MBProjectile : MonoBehaviour {

    public MirageBomb mirageParent; 
    public string parentName = string.Empty;
    public int damage;
    public int currentDamage;
    public int bombRadius;
    public string currentEffect;
    public float effectDuration;
    public float effectStrength;
    public int effectDamage;
    Rigidbody projectileBody;
    public float speed;
    public float speedV;
    float explosionTime;
    Vector3 movement;
    public Transform bombT;
    public GameObject explosion;
    GameObject explClone;
    public Vector3 bombV;
    public LayerMask layer; 
    Renderer bombRend;
    SphereCollider bombColl;
    public AudioSource bombSound; 

    // Use this for initialization
    void Start () {

        speed = 15f;
        speedV = 10f;
        projectileBody = GetComponent<Rigidbody>();
        currentDamage = damage;
        bombRadius = 15;
        explosionTime = 3;
        bombRend = gameObject.GetComponent<Renderer>();
        bombColl = gameObject.GetComponent<SphereCollider>();
        bombSound = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        //movement = new Vector3(0, 1 * speedV, 1 * speed) * Time.deltaTime;
        movement = new Vector3(0, Mathf.Clamp(1 * speedV, 0, 50), 1 * speed) * Time.deltaTime;
        //projectileBody.velocity = transform.TransformDirection(movement);
        //projectileBody.transform.position += movement;
        projectileBody.position += transform.TransformDirection(movement);
        bombV = projectileBody.position;
        bombT = gameObject.transform;

        

    }

    void OnCollisionEnter(Collision collision)
    {
        explClone = Instantiate(explosion, bombV, bombT.rotation);
        bombRend.enabled = false;
        speed = 0;
        speedV = 0;
        bombColl.enabled = false;
        bombSound.Play();

        Collider[] targets = Physics.OverlapSphere(bombV, bombRadius, layer, QueryTriggerInteraction.UseGlobal);

        foreach (Collider enemy in targets)
        {
            if (enemy.gameObject.tag == "Enemy")
            {
                enemy.GetComponent<EnemyDamage>().Hit(currentDamage);

                switch (currentEffect)
                {
                    case "Stun":
                        enemy.GetComponent<StatusStates>().Stun(effectDuration);
                        break;

                    case "Knockback":
                        enemy.GetComponent<StatusStates>().Knockback(effectStrength);
                        break;

                    case "Burn":
                        enemy.GetComponent<StatusStates>().Burn(effectDuration);
                        break;

                    case "Poison":
                        enemy.GetComponent<StatusStates>().Poison(effectDuration, effectDamage);
                        break;
                }
            }

            else
            {

            }
        }

        StartCoroutine(DestroyObject());
    }

    IEnumerator DestroyObject()
    {
        yield return new WaitForSeconds(1f);
        Destroy(explClone);
        Destroy(gameObject); 
    }


}
