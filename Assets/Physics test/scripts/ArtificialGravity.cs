using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtificialGravity : MonoBehaviour {
    public float attenuation = .5f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
         GetComponent<Rigidbody>().AddForce((GetVector()*attenuation),ForceMode.Force);
	}

    private Vector3 GetVector()
    {
        Vector3 heading =   transform.position - new Vector3(0,0,0); // get the vector between the center and this object
        float distance = heading.magnitude;
        Vector3 direction = heading / distance; // This is now the normalized direction.
        print(direction);
        return direction;

    }
}
