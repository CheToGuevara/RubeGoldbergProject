using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportManager : MonoBehaviour {

    public TeleportTrigger[] m_triggers;
	// Use this for initialization
	void Start () {
        for(int i=0; i < m_triggers.Length;i++)
        {
            m_triggers[i].teleporternumber = i;
        }
	}
	
	public void detectBallinTeleport(int numofteleport,GameObject ball)
    {
        int numoft = ((numofteleport + 1) % m_triggers.Length);
        Transform otherteleport =  m_triggers[numoft].transform;
        m_triggers[numoft].DeActivateCollider();
        Debug.Log(otherteleport.up * 10);
        ball.transform.position = otherteleport.position + otherteleport.forward*0.5f;


    }
}
