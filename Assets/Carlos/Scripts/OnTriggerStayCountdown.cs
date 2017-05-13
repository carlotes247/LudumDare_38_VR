using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerStayCountdown : MonoBehaviour {

    // Timer to count seconds
    private TimerController m_Timer;

    // the amount of seconds to count
    public float SecondsToCount;

    // The tag of the trigger
    public string TagToCompare;

    // Position to respawn
    public Transform m_PosToRespawn;

	// Use this for initialization
	void Start () {
        //m_PosToRespawn = this.transform.position;
        m_Timer = this.gameObject.AddComponent<TimerController>();
        m_Timer.ObjectLabel = "Respawn_Timer";
	}

    // Ontriggerstay we run the countdown
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag(TagToCompare))
        {
            if (m_Timer.GenericCountDown(SecondsToCount))
            {
                // When countdown finished, we respawn the object
                RespawnObject();
            }
        }
            
    }

    // OnTriggerExit we stop the countdown
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(TagToCompare))
        {
            m_Timer.StopTimer();
        }
    }

    // Respawns the object somewhere
    private void RespawnObject()
    {
        this.transform.position = m_PosToRespawn.position;
    }
}
