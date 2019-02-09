using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VituaScript : MonoBehaviour {
    Rigidbody rb;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Shot")
        {
            rb.AddForce(0, 10, 13, ForceMode.Impulse);
        }
    }

}
