using UnityEngine;
using System.Collections;

public class TargetSetToMousePos : MonoBehaviour {


    Vector3 pos;
    playerMovement playerMovementScript;
    GameObject thePlayer;
    // Use this for initialization
    void Start () {
        thePlayer = GameObject.Find("Player");
        playerMovementScript = thePlayer.GetComponent<playerMovement>();
        pos = playerMovementScript.positionMouse;
    }
	
	// Update is called once per frame
	void Update () {

        pos = playerMovementScript.positionMouse;
        pos.y = 2f;
        transform.position = pos;

    }
}
