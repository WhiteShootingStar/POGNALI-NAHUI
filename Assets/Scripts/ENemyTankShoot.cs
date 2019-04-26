using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Effects;

public class ENemyTankShoot : MonoBehaviour
{
    public Rigidbody rigid;
    public float speed = 10;
    public GameObject Explosion;
    void start()
    {
        rigid = GetComponent<Rigidbody>();
        transform.Rotate(-90, 0, 0);
        print(transform.rotation);
        gameObject.GetComponent<ExplosionPhysicsForce>().explosionForce = 0;
        //  rigid.transform.Rotate(0, 0, -90);

    }


    public void Update()
    {

        transform.Translate(Vector3.forward * Time.fixedDeltaTime * speed * 15);
        //  rigid.transform.Translate(Vector3.down * Time.fixedDeltaTime * speed*15 );
        //  transform.Translate(Vector3.down * Time.fixedDeltaTime * speed);

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Tower")
        {

            if (other.gameObject.GetComponent<TowerScript>().hp > 0)
            {
                other.gameObject.GetComponent<TowerScript>().hp -= Random.Range(25, 32);
            }
            print(other.gameObject.GetComponent<TowerScript>().hp);
            Instantiate(Explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }

        else if (other.tag == "Body")
        {
            other.gameObject.GetComponent<TankMovingscript>().hp -= Random.Range(45, 65);
            other.gameObject.GetComponent<TankMovingscript>().tower.hp -= Random.Range(15, 25);
            //    print(other.gameObject.GetComponent<TankMovingscript>().hp);
            Instantiate(Explosion, transform.position, transform.rotation);
            Destroy(gameObject);


        }
       
        else
        {
            Instantiate(Explosion, transform.position, transform.rotation);
            print(other.tag);
            Destroy(gameObject);
        }
    }
}
