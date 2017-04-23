using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OarScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerStay(Collider otherCollider)
    {
        if (otherCollider.gameObject.CompareTag("GameController"))
        {
            HandScript handScript_collider = otherCollider.gameObject.GetComponent<HandScript>();
            if (handScript_collider.isHandClosed())
            {
                gameObject.transform.position = otherCollider.gameObject.transform.position;
                gameObject.transform.localRotation = otherCollider.gameObject.transform.localRotation;
            }
        }
    }
}
