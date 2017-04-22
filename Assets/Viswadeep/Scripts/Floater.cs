using UnityEngine;
using System.Collections;

public class Floater : MonoBehaviour {
	public float waterLevel, floatHeight;
	public Vector3 buoyancyCentreOffset;
	public float bounceDamp;

    private Rigidbody rigidBody_this;

    void Start()
    {
        rigidBody_this = GetComponent<Rigidbody>();
    }

	void FixedUpdate () {
		Vector3 actionPoint = transform.position + transform.TransformDirection(buoyancyCentreOffset);
		float forceFactor = 1f - ((actionPoint.y - waterLevel) / floatHeight);
		
		if (forceFactor > 0f) {
            Vector3 uplift = -Physics.gravity * (forceFactor - rigidBody_this.velocity.y * bounceDamp);
            rigidBody_this.AddForceAtPosition(uplift, actionPoint);
		}
	}
}
