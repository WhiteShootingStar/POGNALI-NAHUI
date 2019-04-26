using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Rocket : MonoBehaviour {
  public  Rigidbody rb;
    public float speed = 15;
   public  GameObject exp;
   // public GameObject tank;
  
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        rb.transform.Rotate(90, 0, 0);
        //  tank = GameObject.Find("T-90");

       
    }
	
   
	// Update is called once per frame
	public virtual void FixedUpdate () {
        rb.transform.Translate(-Vector3.up*Time.fixedDeltaTime*speed*15);
       // rb.transform.Translate(Vector3.forward * Time.fixedDeltaTime * speed*0.1f );
          rb.transform.Translate(-Vector3.back * Time.fixedDeltaTime * 15);

    }

    public virtual  void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Obstacle")
        {
            // exp.SetActive(true);
            Instantiate(exp, transform.position, transform.rotation);
            Destroy(gameObject);
            
            print(other.tag);
        }
        else if(other.tag == "Vitya")
        {
            other.GetComponent<Rigidbody>().AddForce(0, 100, 130, ForceMode.Impulse);
            Instantiate(exp, transform.position, transform.rotation);
            Destroy(gameObject);
            print(other.tag);
        }
       
       else if (other.tag == "Tom")
        {
       
            Instantiate(exp, transform.position, transform.rotation);
            Destroy(gameObject);
            print(other.tag);
            Destroy(other.gameObject);
        }                             // 

        else if (other.tag == "Terrorist")
        {

            other.gameObject.GetComponent<Terrorist>().hp -=Random.Range(100,130);
            Instantiate(exp, transform.position, transform.rotation);
            Destroy(gameObject);

        }
        else if(other.tag == "EnemyTank")
        {
            Instantiate(exp, transform.position, transform.rotation);
            other.gameObject.GetComponent<EnemyTanKScript>().hp -= Random.Range(120, 220);
            print(other.gameObject.GetComponent<EnemyTanKScript>().hp);
            Destroy(gameObject);
        }
        else
        {
           
            Instantiate(exp, transform.position, transform.rotation);
            Destroy(gameObject);
        }
      
    }
    }
        
    
