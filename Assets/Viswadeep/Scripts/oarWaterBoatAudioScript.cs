using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class oarWaterBoatAudioScript : MonoBehaviour {
    AudioSource audioSrc;
    public AudioClip waterClick;
    float maxSpeed = 3.5f;

    Vector3 prevPos;
    public float currentSpeed = 0.0f;
    float timeTillNextSound = 0.0f;

	// Use this for initialization
	void Start () {
        audioSrc = GetComponent<AudioSource>();
        waterClick.LoadAudioData();
        audioSrc.clip = waterClick;
        prevPos = gameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        currentSpeed = Vector3.Magnitude(gameObject.transform.position - prevPos) / Time.deltaTime;
        if(currentSpeed>maxSpeed)
        {
            maxSpeed = currentSpeed;
        }

        if (!audioSrc.isPlaying && currentSpeed>1 && timeTillNextSound<=0)
        {
            timeTillNextSound = 1-currentSpeed / maxSpeed;
            if (timeTillNextSound < 0) { timeTillNextSound = 0.0f; }
            audioSrc.Play();
        }
        prevPos = gameObject.transform.position;
        timeTillNextSound -= Time.deltaTime;

    }

}
