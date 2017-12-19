using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour {
    public float speed = .5f;
    public float turnSpeed = .5f;
    private Rigidbody rb;
    public Vector2 movement;
    private Transform charTransform;

    [Header("Auto Upright")]
    private RaycastHit hit;
    private int flipTimer;

    public bool flipped = false;

    [Header("DEBUG")]
    public MeshRenderer mr;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        charTransform = GetComponent <Transform>();
    }
	
	// Update is called once per frame
	void Update () {
        movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        rb.AddTorque(charTransform.up * movement.x * turnSpeed);
        rb.AddForce(charTransform.forward * movement.y * speed, ForceMode.Impulse);
        if (flipped)
        {
           // FlipOver();
            flipped = false;
        }
	}

    private void FlipOver()
    {
        Vector3 ArtificialUp = Vector3.zero - charTransform.position ; // find the World "up" for this object
        Vector3 NormArtificialUp = ArtificialUp / ArtificialUp.magnitude; // This is now the normalized direction.
        rb.AddForce(NormArtificialUp * 10, ForceMode.Impulse);
        charTransform.rotation = Quaternion.FromToRotation(charTransform.rotation.eulerAngles, hit.normal);
    }

   


    











    //Here be DEBUG, all ye beware!
    private void OnCollisionEnter(Collision collision)
    {
       
            mr.material.SetColor("_EmissionColor", Color.green);
            print("you hit something");
        
    }
    private void OnCollisionExit(Collision collision)
    {
            mr.material.SetColor("_EmissionColor", Color.red);
            print("now thats what I call flying ");
    }
}
