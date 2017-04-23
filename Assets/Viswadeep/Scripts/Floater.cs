using UnityEngine;
using System.Collections;

public class Floater : MonoBehaviour {
	public float waterLevel, floatHeight;
	public Vector3 buoyancyCentreOffset;
	public float bounceDamp;
    public AudioClip waterDrop;

    private Rigidbody rigidBody_this;

    void Start()
    {
        rigidBody_this = GetComponent<Rigidbody>();
        if (floatHeight == null || floatHeight == 0.0f) { floatHeight = 0.01f; }
        waterDrop.LoadAudioData();
    }

	void FixedUpdate () {
/**		Vector3 actionPoint = transform.position + transform.TransformDirection(buoyancyCentreOffset);
		float forceFactor = 1f - ((actionPoint.y - waterLevel) / floatHeight);
		
		if (forceFactor > 0f) {
            Vector3 uplift = -Physics.gravity * (forceFactor - rigidBody_this.velocity.y * bounceDamp);
            rigidBody_this.AddForceAtPosition(uplift, actionPoint);
		}*/
	}

    void OnTriggerEnter(Collider otherCollider)
    {
        if (otherCollider.gameObject.CompareTag("Water"))
        {
            AudioSource audioSource = new AudioSource();
            audioSource.clip = waterDrop;
            audioSource.Play();
        }
    }


    void OnTriggerStay(Collider otherCollider)
    {
        if (otherCollider.gameObject.CompareTag("Water"))
        {
            Vector3 actionPoint = transform.position + transform.TransformDirection(buoyancyCentreOffset);
            float forceFactor = 1f - ((actionPoint.y - otherCollider.gameObject.transform.position.y) / floatHeight);

            if (forceFactor > 0f)
            {
                Vector3 uplift = -Physics.gravity * (forceFactor - rigidBody_this.velocity.y * bounceDamp);
                rigidBody_this.AddForceAtPosition(uplift, actionPoint);
            }
        }


/**        if (otherCollider.gameObject.CompareTag("GameController"))
        {
            HandScript handScript_collider = otherCollider.gameObject.GetComponent<HandScript>();
            if (handScript_collider.isHandClosed())
            {
                gameObject.transform.position = otherCollider.gameObject.transform.position;
                gameObject.transform.localRotation = otherCollider.gameObject.transform.localRotation;
            }
        }*/
    }
}
