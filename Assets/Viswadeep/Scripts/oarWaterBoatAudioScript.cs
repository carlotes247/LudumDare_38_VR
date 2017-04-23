using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class oarWaterBoatAudioScript : MonoBehaviour {
    AudioSource audioSrc;
    public AudioClip waterClick;
    public GameObject playAreaGO;
    VRTK_MoveInPlace_CARLOS playAreaMovementScript;

    Rigidbody boatRB;

    float audioSrcLeftTimeLeft=0.0f;
    float maxSpeed;

	// Use this for initialization
	void Start () {
        audioSrc = new AudioSource();
        waterClick.LoadAudioData();
        audioSrc.clip = waterClick;
        playAreaMovementScript = playAreaGO.GetComponent<VRTK_MoveInPlace_CARLOS>();
        maxSpeed=playAreaMovementScript.maxSpeed;
	}
	
	// Update is called once per frame
	void Update () {
        

        if (audioSrcLeftTimeLeft <= 0.1)
        {
            float playAreaSpeed = playAreaMovementScript.GetSpeed();
            audioSrcLeftTimeLeft = (maxSpeed - playAreaSpeed) / maxSpeed;
            audioSrc.Play();
        }
        audioSrcLeftTimeLeft -= Time.deltaTime;
	}

}
