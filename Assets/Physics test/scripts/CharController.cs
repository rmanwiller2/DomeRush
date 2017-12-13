using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour {
    public float speed = .5f;
    public float turnSpeed = .5f;
    private Rigidbody rb;
    public Vector2 movement;
    [Header("DEBUG")]
    public MeshRenderer mr;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();

    }
	
	// Update is called once per frame
	void Update () {
        movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        rb.AddTorque( transform.up * movement.x * turnSpeed);
        rb.AddForce(transform.forward * movement.y * speed, ForceMode.Impulse);
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
