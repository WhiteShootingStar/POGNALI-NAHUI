using UnityEngine;
using UnityStandardAssets.Effects;

public class rocketTer : MonoBehaviour
{
    public Rigidbody rigid;
    public float speed = 10000;
    public GameObject Explosion;
    void start()
    {
        rigid = GetComponent<Rigidbody>();
        gameObject.GetComponent<ExplosionPhysicsForce>().explosionForce = 0;
      // rigid.transform.Rotate(-180, 0, 0);
    }


    public  void FixedUpdate()
    {
        rigid.transform.Translate(Vector3.up * Time.fixedDeltaTime * speed * 15);
        // rb.transform.Translate(Vector3.forward * Time.fixedDeltaTime * speed*0.1f );
      rigid.transform.Translate(Vector3.back * Time.fixedDeltaTime * 15);
    }

    public  void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Tower")
        {

            other.GetComponent<TankMovingscript> ().tower.hp -= Random.Range(25, 32);
            print(other.gameObject.GetComponent<TankMovingscript>().tower.hp);
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

    }
}
