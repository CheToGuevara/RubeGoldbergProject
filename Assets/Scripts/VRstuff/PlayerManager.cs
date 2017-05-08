using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    public GameObject m_camera;


    public void onTeleportTrigger()
    {
        RaycastHit hit;


        if (Physics.Raycast(m_camera.transform.position, m_camera.transform.forward, out hit))
        {
            m_camera.transform.position = hit.point + new Vector3(0, 1, 0);
        }
    }



}
