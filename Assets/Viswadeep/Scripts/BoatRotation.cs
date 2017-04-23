using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatRotation : MonoBehaviour {

    Rigidbody thisRigidBody;

    public int rotationSpeed = 1;
	// Use this for initialization
	void Start () {
        thisRigidBody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(thisRigidBody.velocity), Time.deltaTime * rotationSpeed);
	}
}
