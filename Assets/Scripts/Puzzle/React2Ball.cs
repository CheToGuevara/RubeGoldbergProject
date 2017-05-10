using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class React2Ball : MonoBehaviour {

    public bool iamafan = false;

    private Transform m_blades;
	// Use this for initialization
	void Start () {
		if (iamafan)
        {
            m_blades = transform.GetChild(0);
            InvokeRepeating("onRotation", 0.5f, 0.1f);
        }
	}


    private void onRotation()
    {
        m_blades.Rotate(transform.forward*Time.deltaTime*1000);
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.transform.CompareTag("Throwable"))
        {
            Debug.Log(collision.relativeVelocity  * 100  );
            collision.gameObject.GetComponent<Rigidbody>().AddForce( collision.relativeVelocity.x * 50, -collision.relativeVelocity.y * 50, collision.relativeVelocity.z * 50);
        }
            
    }

    private void OnTriggerEnter(Collider other)
    {
        if (transform.CompareTag("Throwable"))
        {
            //Debug.Log();
            other.gameObject.GetComponent<Rigidbody>().AddForce(transform.up);
        }
        else if(transform.CompareTag("Collectable"))
                {
            
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerStay(Collider other)
    {

        if (other.transform.CompareTag("Throwable"))
        {
            Debug.Log("Esto");
            other.gameObject.GetComponent<Rigidbody>().AddForce(transform.forward*10);
        }
    }
    
}
