using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackerController : MonoBehaviour {
    public Renderer trackedObject;
    private Renderer trackerRend;
    public bool FogOfWar = true;
    public bool discovered = false;
	// Use this for initialization
	void Start () {
        trackerRend = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!FogOfWar)
        {
            
            if (trackedObject.isVisible) { trackerRend.enabled = false; } else { trackerRend.enabled = true; }
        }
        else
        {
            
            if (discovered) {  if (trackedObject.isVisible) { trackerRend.enabled = false;  } else { trackerRend.enabled = true; } }
        }
        if (trackedObject.isVisible) { discovered = true; }
    }
}
