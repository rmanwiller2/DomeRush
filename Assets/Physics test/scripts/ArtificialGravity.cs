using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtificialGravity : MonoBehaviour {
    [Tooltip("Multiplier for the artificial gravity force")]
    public float strength = .5f;
    public float airMultiplier = 2;
    private RaycastHit hit;
    [Header("DEBUG")]
    public Vector3 HitNormal;
    public Vector3 gravityDir;
    private Rigidbody rb;
    private int collCount;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        rb.AddForce((GetVector()*strength),ForceMode.Force);
        //rb.AddExplosionForce(-10, Vector3.zero, 0); // cheesy gravity [bad]
        //AlignToVector();
	}

    private Vector3 GetVector()
    {
        //Vector3 heading =  transform.position - new Vector3(0, 0, 0); // get the vector between the center and this object
        Vector3 heading = new Vector3(0, 0, 0) - transform.position; // get the vector between the center and this object
        float distance = heading.magnitude;
        Vector3 direction = heading / distance; // This is now the normalized direction.
        gravityDir = direction; //DEBUG
        return direction;

    }
    void AlignToVector()
    {
        Vector3 castPos = new Vector3(transform.position.x, transform.position.y - .25f, transform.position.z);
        if (Physics.Raycast(castPos, -transform.up, out hit))
        {
            HitNormal = hit.normal;
            transform.rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collCount != 0) { strength /= airMultiplier; } //set gravity back to normal strength while on the ground
        if (collCount == 0) { collCount++; }               //use this to disable the first collision
           
    }
    private void OnCollisionExit(Collision collision)
    {
        strength *= airMultiplier; //multiply gravity while in the air so it sucks you down fast.
        //AlignToVector();
        //print("aligning");

    }
}
