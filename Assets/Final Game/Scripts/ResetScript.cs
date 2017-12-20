using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetScript : MonoBehaviour {
    public GameObject Ball;
    public GameObject Goal; // these are the prefabs used for placing all the new stuff
    public GameObject Player;

    private Vector3 newGoalPos;
    private Vector3 newBallPos;
    private Vector3 newPlayerPos;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


    }

    public void NewRound()
    {

        //change domes/environments at this time
        //raycast out from center to random location on dome
        //place new prefabs
        //remove old scene items
        //the end
        // ???
        //profit

        newBallPos = new Vector3(Random.Range(-300,300), Random.Range(-300, 300), Random.Range(-300, 300));

        RaycastHit hit;

        if (Physics.Raycast(transform.position, (newBallPos - Vector3.zero), out hit))
            print("Found an object - distance: " + hit.distance+ "position: "+hit.point);




    }



}

