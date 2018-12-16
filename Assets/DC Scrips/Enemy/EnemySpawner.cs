using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
   public GameObject enemyObject;
    GameObject instanceObj;
    Vector3 parentPosition;
    public int maxSpawn = 0;
    List<GameObject> aliveEnemies;
    int deadEnemies;
    bool encountered = false;
    

	// Use this for initialization
	void Start () {
        parentPosition = gameObject.transform.position;
        aliveEnemies = new List<GameObject>();
        


    }
	
	// Update is called once per frame
	void Update () {
        if (deadEnemies == maxSpawn && encountered == true)
        {
            Destroy(gameObject);
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            StartCoroutine(SpawnEnemy());
        }

    }

    IEnumerator SpawnEnemy()
    {
        for(int i = 0; i <= Random.Range(2, 4); i++)
        {
            if (maxSpawn <= i)
            {
                aliveEnemies.Add( instanceObj = Instantiate(enemyObject, parentPosition, Quaternion.identity));
                instanceObj.transform.SetParent(this.transform);
                maxSpawn++;
                yield return new WaitForSeconds(2);
            }

            else
            {
                break;
            }
        }

        encountered = true;
        
    }

    public void RemoveSpawn()
    {
        deadEnemies++;
        Debug.Log("Dead Enemies Count " + deadEnemies);
    }
}
