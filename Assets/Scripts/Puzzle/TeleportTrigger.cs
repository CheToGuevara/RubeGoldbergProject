using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportTrigger : MonoBehaviour
{

    public TeleportManager teleportmanager;

    public int teleporternumber;

    public Collider myownCollider;
    // Use this for initialization
    

    private void OnTriggerEnter(Collider other)
    {
        teleportmanager.detectBallinTeleport(teleporternumber, other.gameObject);
        DeActivateCollider();
    }

    private void ReEnableCollider()
    {
        myownCollider.enabled = true;
    }

    public void DeActivateCollider()
    {
        myownCollider.enabled = false;
        Invoke("ReEnableCollider", 1);
    }

}
