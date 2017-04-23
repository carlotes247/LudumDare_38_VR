using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatRotation : MonoBehaviour {

    Rigidbody thisRigidBody;
    Vector3 velocityDirection;

    public int rotationSpeed = 1;
	// Use this for initialization
	void Start () {
        thisRigidBody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        velocityDirection = new Vector3(thisRigidBody.velocity.x, 0, thisRigidBody.velocity.z);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(velocityDirection), Time.deltaTime * rotationSpeed);
	}
}
