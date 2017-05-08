using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerSounds : MonoBehaviour {

    // Use this for initialization
    public AudioClip teleportGo;
    public AudioClip teleportLoop;
    public AudioClip teleportExit;
    
    public AudioSource m_audiosource;

    private GameManager m_gamemanager;

    private void Start()
    {
        m_gamemanager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void onPointerEnter()
    {
        m_audiosource.clip = teleportLoop;
        m_audiosource.loop = true;
        m_audiosource.Play();
    }

    public void onPointerClick()
    {
       
        m_audiosource.clip = teleportGo;
        m_audiosource.loop = false;
        m_audiosource.Play();

        m_gamemanager.onTeleportTrigger();
    }


    public void onPointerExit()
    {
        m_audiosource.loop = false;
        
        m_audiosource.Stop();
    }



}
