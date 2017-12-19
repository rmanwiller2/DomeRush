using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalController : MonoBehaviour {
    private ParticleSystem particles;
    public GameObject ScriptCache;
    private ResetScript reset;
    // Use this for initialization
    void Start () {
        particles = GetComponent<ParticleSystem>();
        reset = ScriptCache.GetComponent<ResetScript>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            particles.Play();
            //points increase
            //start countdown to new round //call GUI Countdown
            reset.NewRound();
            // move goal to new location
        }
    }
}
