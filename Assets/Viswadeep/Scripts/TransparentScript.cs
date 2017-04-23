using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransparentScript : MonoBehaviour {
    Color dropColor;
    public float transparency = 0.3f;
    Renderer thisRenderer;

	// Use this for initialization
	void Start () {
        thisRenderer = gameObject.GetComponent<Renderer>();
        dropColor = thisRenderer.material.color;
        dropColor.a = transparency;
        thisRenderer.material.color = dropColor;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
