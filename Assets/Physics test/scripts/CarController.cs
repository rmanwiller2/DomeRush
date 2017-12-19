using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{

    public Transform[] wheels;
    public Transform[] meshWheels;
    public float enginePower = 150.0f;

    public float power = 0.0f;
    public float brake = 0.0f;

    public float steer = 0.0f;
    public float maxSteer = 25.0f;

    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = new Vector3(0, -0.5f, 0.3f);
    }

    void Update()
    {
        power = Input.GetAxis("Vertical") * enginePower * Time.deltaTime * 250.0f;
        steer = Input.GetAxis("Horizontal") * maxSteer;
        if (Input.GetKey("space")) { brake =rb.mass * 10000000; } else { brake = 0.0f; }

        GetCollider(0).steerAngle = steer;
        GetCollider(1).steerAngle = steer;
        

        if (brake > 0.0)
        {
            GetCollider(0).brakeTorque = brake;
            GetCollider(1).brakeTorque = brake;
            GetCollider(2).brakeTorque = brake;
            GetCollider(3).brakeTorque = brake;
            GetCollider(2).motorTorque = 0.0f;
            GetCollider(3).motorTorque = 0.0f;
        }
        else
        {
            GetCollider(0).brakeTorque = 0;
            GetCollider(1).brakeTorque = 0;
            GetCollider(2).brakeTorque = 0;
            GetCollider(3).brakeTorque = 0;
            GetCollider(2).motorTorque = power;
            GetCollider(3).motorTorque = power;
        }
        meshWheels[0].localEulerAngles = new Vector3(meshWheels[0].localEulerAngles.x, GetCollider(0).steerAngle - meshWheels[0].localEulerAngles.z, meshWheels[0].localEulerAngles.z);
        meshWheels[1].localEulerAngles = new Vector3(meshWheels[1].localEulerAngles.x, GetCollider(1).steerAngle - meshWheels[1].localEulerAngles.z, meshWheels[1].localEulerAngles.z);

        meshWheels[0].Rotate(GetCollider(0).rpm / 60 * 360 * Time.deltaTime, 0, 0);
        meshWheels[1].Rotate(GetCollider(1).rpm / 60 * 360 * Time.deltaTime, 0, 0);
        meshWheels[2].Rotate(GetCollider(2).rpm / 60 * 360 * Time.deltaTime, 0, 0);
        meshWheels[3].Rotate(GetCollider(3).rpm / 60 * 360 * Time.deltaTime, 0, 0);
    }

    WheelCollider GetCollider(int n)
    {
        return wheels[n].gameObject.GetComponent<WheelCollider>();
    }
}