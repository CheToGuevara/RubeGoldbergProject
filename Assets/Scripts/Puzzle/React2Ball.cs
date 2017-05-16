using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class React2Ball : MonoBehaviour {

    public bool iamafan = false;
    public Animation m_gloveanimation;

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
        if (transform.CompareTag("Glove"))
        {
            Debug.Log("Shot");
            collision.gameObject.GetComponent<Rigidbody>().AddForce(0,0,0);
            //transform.position = new Vector3(0, 0, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (transform.CompareTag("Glove"))
        {
            Debug.Log("Shot");
            m_gloveanimation.Play();
            //transform.position = new Vector3(0, 0, 0);
        }
            if (transform.CompareTag("Goal"))
        {
            Debug.Log("Finish");
            other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        }
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

        if (transform.CompareTag("Fan"))
        {
            Debug.Log("Esto");
            other.gameObject.GetComponent<Rigidbody>().AddForce(transform.forward*10);
        }
    }
    
}
