using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodInstantiater_Script : MonoBehaviour {

    public float instantiate_delay = 1;
    public float instantiate_delay_multiplier=1;
    public float instantiate_delay_multiplier_change = 0.01f;
    public GameObject[] foodPrefabs;
    public int x_min;
    public int x_max;
    public int y_min;
    public int y_max;
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
            Vector3 position = new Vector3(Random.Range(x_min, x_max), food_instantiate_height, Random.Range(y_min, y_max));
            GameObject food = foodPrefabs[Random.Range(0, foodPrefabs.Length)];
            GameObject.Instantiate(food, position, Quaternion.identity);

            time_elapsed = 0.0f;
            instantiate_delay_multiplier -= instantiate_delay_multiplier_change;
            if (instantiate_delay_multiplier <= 0) { instantiate_delay_multiplier = instantiate_delay_multiplier_change; }
        }
	}
}
