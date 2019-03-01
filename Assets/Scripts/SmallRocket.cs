using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallRocket : MonoBehaviour
{
    Rigidbody rb;
    public float speed = 10000;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.transform.Rotate(90, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        rb.transform.Translate(-Vector3.up * Time.fixedDeltaTime * speed * 15);
        rb.transform.Translate(Vector3.forward * Time.fixedDeltaTime * speed * 0.1f);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Terrorist"))
        {
            other.gameObject.GetComponent<Terrorist>().hp -= Random.Range(8, 11);
            print(other.gameObject.GetComponent<Terrorist>().hp);
        }
    }


}
