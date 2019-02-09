using System.Collections;
using System.Collections.Generic;
using UnityEngine;





public class FenceScript : MonoBehaviour
{
    Rigidbody rb;
    
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
       
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Shot")
        {
          rb.AddRelativeForce(new Vector3(Random.value, 1, Random.value) * 20, ForceMode.Impulse);
            Destroy(gameObject, 7);
        }
    }
}
