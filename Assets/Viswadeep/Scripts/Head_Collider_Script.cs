using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head_Collider_Script : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerStay(Collider otherCollider)
    {
        if (otherCollider.gameObject.CompareTag("Food"))
        {
            DestroyObject(otherCollider.gameObject);
        }
    }
}
