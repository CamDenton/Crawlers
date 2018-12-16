using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class WinCondition : MonoBehaviour {

    public bool isComplete = false;
    public WCSpawns destroyedAll;
    public Canvas victoryCanvas; 

    void Start()
    {
        victoryCanvas.enabled = false;
    }

    void Update()
    {
        if (destroyedAll.isComplete == true || destroyedAll == null)
        {
            isComplete = true;
            Debug.Log(isComplete + " - Objective Complete");
            
        }

        if (isComplete == true)
        {
            victoryCanvas.enabled = true;
            SceneManager.LoadSceneAsync(0);
            
        }
    }

}
