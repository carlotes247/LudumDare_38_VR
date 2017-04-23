using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodInstantiater_Script : MonoBehaviour {

    public float instantiate_delay = 1;
    public float instantiate_delay_multiplier=1;
    public float instantiate_delay_multiplier_change = 0.0f;
    public GameObject[] foodPrefabs;
    public int xMin;
    public int xMax;
    public int zMin;
    public int zMax;
    public int food_instantiate_height=5;

    float time_elapsed=0;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        time_elapsed += Time.deltaTime;

        if ((instantiate_delay_multiplier * time_elapsed) > instantiate_delay)
        {
            Vector3 position = new Vector3(Random.Range(xMin, xMax), food_instantiate_height, Random.Range(zMin, zMax));
            GameObject food = foodPrefabs[Random.Range(0, foodPrefabs.Length)];
            GameObject.Instantiate(food, position, Quaternion.identity);

            time_elapsed = 0.0f;
            instantiate_delay_multiplier -= instantiate_delay_multiplier_change;
            if (instantiate_delay_multiplier <= 0) { instantiate_delay_multiplier = instantiate_delay_multiplier_change; }
        }
	}
}
