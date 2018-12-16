using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuButtons : MonoBehaviour {
    public AudioSource uiSound;
    
	// Use this for initialization
	void Start () {
        
	}
	
	public void StartGame()
    {

        uiSound.Play();
        SceneManager.LoadSceneAsync(1, LoadSceneMode.Single);
        

    }
}
