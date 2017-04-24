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

    AudioSource headAudioSource;
    public AudioClip biteSound;

    public bool m_GameStarted;
    public FoodInstantiater_Script m_FoodSpawner;

	// Use this for initialization
	void Start () {
        headAudioSource = GetComponent<AudioSource>();
        headAudioSource.clip = biteSound;
	}
	
	// Update is called once per frame
	void Update () {
        if (m_GameStarted)
        {
            currentHealth -= hungerMultiplier * Time.deltaTime;
            if (currentHealth <= 0)
            {
                currentHealth = 0;
                Debug.Log("Dead!");
            }

            healthBar.sizeDelta = new Vector2(currentHealth / 10, healthBar.sizeDelta.y); 
        }
    }
	

    void OnTriggerStay(Collider otherCollider)
    {
        if (otherCollider.gameObject.CompareTag("Food"))
        {
            eatFood(foodPoints);
            GameObject foodDeathInstance = GameObject.Instantiate(foodDeathAnimation, otherCollider.gameObject.transform.position, Quaternion.identity);
            DestroyObject(otherCollider.gameObject);
            DestroyObject(foodDeathInstance, 0.25f);
            headAudioSource.Play();
        }
        else if (otherCollider.gameObject.CompareTag("ExitOption"))
        {
            GameObject foodDeathInstance = GameObject.Instantiate(foodDeathAnimation, otherCollider.gameObject.transform.position, Quaternion.identity);
            DestroyObject(otherCollider.gameObject);
            DestroyObject(foodDeathInstance, 0.25f);
            headAudioSource.Play();
            QuitGame();
        }
        else if (otherCollider.gameObject.CompareTag("PlayOption"))
        {
            GameObject foodDeathInstance = GameObject.Instantiate(foodDeathAnimation, otherCollider.gameObject.transform.position, Quaternion.identity);
            DestroyObject(otherCollider.gameObject);
            DestroyObject(foodDeathInstance, 0.25f);
            headAudioSource.Play();
            StartGame();

        }


    }

    public void eatFood(float amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth) { currentHealth = maxHealth; }
    }

    /// <summary>
    /// Exits the application
    /// </summary>
    public void QuitGame()
    {
        // We stop the game logic
        SetGameStart(false);

        //If we are in the editor...
#if UNITY_EDITOR
        //... we exit playmode
        UnityEditor.EditorApplication.isPlaying = false;
#else
        //... if not, we stop execution
        Application.Quit();
#endif
    }


    public void StartGame()
    {
        SetGameStart(true);
    }

    private void SetGameStart (bool value)
    {
        if (m_GameStarted != value)
        {
            m_GameStarted = value;
            m_FoodSpawner.GameStarted = value; 
        }
    }
}
