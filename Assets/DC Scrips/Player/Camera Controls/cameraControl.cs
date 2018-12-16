using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraControl : MonoBehaviour {
    Vector2 mouse;
    Vector2 smoothingv;
    Vector2 mousePos;
    public float sensitivity = 100f;
    public float smoothing = 5f;
    public string playerCamX = "Mouse XP1";
    public string playerCamY = "Mouse YP1";

    GameObject player;



    // Use this for initialization
    void Start()
    {
        //player = transform.parent.gameObject;
        player = this.gameObject;

    }



    // Update is called once per frame
    void Update()
    {


        mousePos = new Vector2(Input.GetAxisRaw(playerCamX), Input.GetAxisRaw(playerCamY));
        mousePos = Vector2.Scale(mousePos, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
        smoothingv.x = Mathf.Lerp(smoothingv.x, mousePos.x, 1f / smoothing);
        smoothingv.y = Mathf.Lerp(smoothingv.y, mousePos.y, 1f / smoothing);
        mouse += smoothingv * Time.deltaTime;
        
            //mouse.y = Mathf.Clamp(mouse.y, 0, 0);
        

        //transform.rotation = Quaternion.AngleAxis(-mouse.y, Vector3.right);
        player.transform.rotation = Quaternion.AngleAxis(mouse.x, player.transform.up);




    }
}
