using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ButtonHandler : MonoBehaviour {

    public GameObject starter;
    ManagePlayers starterManager;
    public AudioSource uiSound;
    void Start()
    {
        starterManager = starter.GetComponent<ManagePlayers>(); 
    }

    void Update()
    {
            
    }

    public void SinglePlayer()
    {
        uiSound.Play();
        starterManager.singleSelected = true;
        SceneManager.LoadSceneAsync(1, LoadSceneMode.Single);
    }

    public void TwoPlayer()
    {
        uiSound.Play();
        starterManager.twoSelected = true;
        SceneManager.LoadSceneAsync(1, LoadSceneMode.Single);
    }
}
