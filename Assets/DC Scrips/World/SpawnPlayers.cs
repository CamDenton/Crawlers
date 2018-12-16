using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class SpawnPlayers : MonoBehaviour {

    public GameObject playersManager;
    ManagePlayers playerManagerComp;

    public GameObject worldManager;
    public Transform playerOne;
    public Transform playerTwo;
    public Transform playerThree;
    public Transform playerFour;

    Vector3 playerOneSpawn;
    Vector3 playerTwoSpawn;
    Vector3 playerThreeSpawn;
    Vector3 playerFourSpawn;

    public GameObject playerOneObj;
    public GameObject playerTwoObj;
    public GameObject playerThreeObj;
    public GameObject playerFourObj;
    public GameObject pOneClone;
    public GameObject pTwoClone;
    public GameObject pThreeClone;
    public GameObject pFourClone;

    public GameObject pOneHUD;
    public GameObject pOneHUDClone;
    public GameObject pTwoHUD;
    public GameObject pTwoHUDClone;

    public GameObject pOneCamObj;
    public GameObject pTwoCamObj;
    public Camera pOneCam;
    public Camera pTwoCam;

    public int pOneSpec;
    public int pTwoSpec;
    public int pThreeSpec;
    public int pFourSpec; 

    public Canvas globalHud;



    public void Awake()
    {
        #region Floor Set Up
       
        playerOne = GameObject.FindGameObjectWithTag("P1Spawn").transform;
        playerTwo = GameObject.FindGameObjectWithTag("P2Spawn").transform;
        playerThree = GameObject.FindGameObjectWithTag("P3Spawn").transform;
        playerFour = GameObject.FindGameObjectWithTag("p4Spawn").transform;

        #endregion

        playersManager = GameObject.Find("PlayersManager");
        worldManager = GameObject.Find("Manager");
        playerManagerComp = playersManager.GetComponent<ManagePlayers>();
        playerOneObj = playerManagerComp.playerOneClass;
        playerTwoObj = playerManagerComp.playerTwoClass;
        playerThreeObj = playerManagerComp.playerThreeClass;
        playerFourObj = playerManagerComp.playerFourClass;

        playerOneSpawn = playerOne.position;
        playerTwoSpawn = playerTwo.position;
        playerThreeSpawn = playerThree.position;
        playerFourSpawn = playerFour.position;

        pOneHUD = playerManagerComp.p1Hud;
        pTwoHUD = playerManagerComp.p2Hud;

        pOneSpec = playerManagerComp.p1SpecialSlot;
        pTwoSpec = playerManagerComp.p2SpecialSlot;
        pThreeSpec = playerManagerComp.p3SpecialSlot;
        pFourSpec = playerManagerComp.p4SpecialSlot;
        

        if (playerManagerComp.singleSelected == true)
        {
            SingleSelected();
        }

        else if(playerManagerComp.twoSelected == true)
        {
            PlayerTwoSelected();
        }

        else if(playerManagerComp.threeSelected == true)
        {
            PlayerThreeSelected();
        }

        else if(playerManagerComp.fourSelected == true)
        {
            PlayerFourSelected();
        }
    }

    private void Start()
    {
        
    }

    public void SingleSelected()
    {

        pOneClone =  Instantiate(playerOneObj, playerOneSpawn, Quaternion.identity);
        pOneHUDClone = Instantiate(pOneHUD, playerOneSpawn, Quaternion.identity);
        pOneCam = pOneClone.GetComponentInChildren<Camera>();
        pOneHUDClone.GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceCamera;
        pOneHUDClone.GetComponent<Canvas>().worldCamera = pOneCam;
        pOneHUDClone.GetComponent<HUDElements>().player = pOneClone;


        pOneClone.AddComponent<PlayerMov>();
        pOneClone.AddComponent<playerAnim>();
        pOneClone.AddComponent<cameraControl>();
        pOneClone.AddComponent<PlayerCombat>();

        pOneClone.GetComponentInChildren<Camera>().rect = new Rect(0, 0, 1, 1);

        if(pOneClone.GetComponent<PlayerStats>().playerClassType.ToString() == "Warrior (Classes)")
        {
            switch (pOneSpec)
            {
                case 1:
                    pOneClone.GetComponent<ExplosiveRoar>().enabled = true;
                    break;

                case 2:
                    pOneClone.GetComponent<WaveBreak>().enabled = true;
                    break;

                case 3:
                    pOneClone.GetComponent<IngressDive>().enabled = true;
                    break;

                case 4:
                    pOneClone.GetComponent<Rally>().enabled = true;
                    break;
            }
        }
        

    }

    public void PlayerTwoSelected()
    {

        pOneClone = Instantiate(playerOneObj, playerOneSpawn, Quaternion.identity);
        pTwoClone = Instantiate(playerTwoObj, playerTwoSpawn, Quaternion.identity);

        pOneHUDClone = Instantiate(pOneHUD, playerOneSpawn, Quaternion.identity);
        pOneCam = pOneClone.GetComponentInChildren<Camera>();
        pOneHUDClone.GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceCamera;
        pOneHUDClone.GetComponent<Canvas>().worldCamera = pOneCam;
        pOneHUDClone.GetComponent<HUDElements>().player = pOneClone;

        pTwoHUDClone = Instantiate(pTwoHUD, playerTwoSpawn, Quaternion.identity);
        pTwoCam = pTwoClone.GetComponentInChildren<Camera>();
        pTwoHUDClone.GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceCamera;
        pTwoHUDClone.GetComponent<Canvas>().worldCamera = pTwoCam;
        pTwoHUDClone.GetComponent<HUDElements>().player = pTwoClone;

        pOneClone.AddComponent<PlayerMov>();
        pOneClone.AddComponent<playerAnim>();
        pOneClone.AddComponent<cameraControl>();
        pOneClone.AddComponent<PlayerCombat>();

        pTwoClone.AddComponent<PlayerMovP2>();
        pTwoClone.AddComponent<PAnimP2>();
        pTwoClone.AddComponent<P2CamCtrl>();
        pTwoClone.AddComponent<P2Combat>();

        pOneClone.GetComponentInChildren<Camera>().rect = new Rect(0, 0.5f, 1, 0.5f);
        pTwoClone.GetComponentInChildren<Camera>().rect = new Rect(0, 0, 1, 0.5f);
    }

    public void PlayerThreeSelected()
    {

        pOneClone = Instantiate(playerOneObj, playerThreeSpawn, Quaternion.identity);
        pTwoClone = Instantiate(playerTwoObj, playerTwoSpawn, Quaternion.identity);
        pThreeClone = Instantiate(playerThreeObj, playerOneSpawn, Quaternion.identity);

        pOneClone.AddComponent<PlayerMov>();
        pTwoClone.AddComponent<PlayerMovP2>();
        pThreeClone.AddComponent<PlayerMovP3>();
    }

    public void PlayerFourSelected()
    {

        pOneClone = Instantiate(playerOneObj, playerOneSpawn, Quaternion.identity);
        pTwoClone = Instantiate(playerTwoObj, playerTwoSpawn, Quaternion.identity);
        pThreeClone = Instantiate(playerThreeObj, playerThreeSpawn, Quaternion.identity);
        pFourClone = Instantiate(playerFourObj, playerFourSpawn, Quaternion.identity);

        pOneClone.AddComponent<PlayerMov>();
        pTwoClone.AddComponent<PlayerMovP2>();
        pThreeClone.AddComponent<PlayerMovP3>();
        pThreeClone.AddComponent<PlayerMovP4>();

    }
}
