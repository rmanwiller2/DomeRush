using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipDetect : MonoBehaviour {
    public GameObject carBody;
    private CharController ControllerScript;
    private float flipTimer;
    public int maxTime = 3; 
	// Use this for initialization
	void Start () {
        ControllerScript = carBody.GetComponent<CharController>();
	}
	
	// Update is called once per frame
	void Update () {
		if (flipTimer >= maxTime)
        {
            ControllerScript.flipped = true;
            flipTimer = 0;
        }
	}
   




    private void OnTriggerStay(Collider other)
    {
        flipTimer += Time.deltaTime;
        print("Flipped!!!!");
    }



    private void OnTriggerExit(Collider other)
    {
        flipTimer = 0; // reset the flipTimer    
    }

}
