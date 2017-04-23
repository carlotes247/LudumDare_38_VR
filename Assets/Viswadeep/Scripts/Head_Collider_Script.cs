using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head_Collider_Script : MonoBehaviour {

    public const float maxHealth = 100;
    public float currentHealth = maxHealth;
    public RectTransform healthBar;
    public float hungerMultiplier=1;
    public float foodPoints = 10;
    public GameObject foodDeathAnimation;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		currentHealth -= hungerMultiplier * Time.deltaTime;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Debug.Log("Dead!");
        }

        healthBar.sizeDelta = new Vector2(currentHealth/10, healthBar.sizeDelta.y);
    }
	

    void OnTriggerStay(Collider otherCollider)
    {
        if (otherCollider.gameObject.CompareTag("Food"))
        {
            eatFood(foodPoints);
            GameObject foodDeathInstance = GameObject.Instantiate(foodDeathAnimation, otherCollider.gameObject.transform.position, Quaternion.identity);
            DestroyObject(otherCollider.gameObject);
            DestroyObject(foodDeathInstance, 0.25f);

        }
    }

    public void eatFood(float amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth) { currentHealth = maxHealth; }
    }
}
