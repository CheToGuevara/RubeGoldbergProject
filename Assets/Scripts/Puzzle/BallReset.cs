using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallReset : MonoBehaviour {


    public Rigidbody m_rigidbody;
    // Use this for initialization
    Vector3 startposition;
    Vector3 zero = new Vector3(0f, 0f, 0f);
    
	void Start () {
        startposition = transform.position;
	}

    // Update is called once per frame


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            transform.position = startposition;
            m_rigidbody.velocity = zero;
            m_rigidbody.angularVelocity = zero;
            transform.rotation = Quaternion.Euler(zero);
        }
            
    }
}
