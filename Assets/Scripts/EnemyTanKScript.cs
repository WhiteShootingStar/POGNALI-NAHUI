using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyTanKScript : MonoBehaviour
{
    public GameObject tower, gun,gunPoint,Burning;
    NavMeshAgent agent;
    public GameObject target;
    public ENemyTankShoot bullet;
    float reloadtimer = 4.5f;
    public int hp = 200;
  float Tower_Angle;
    bool isDead = false;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Body");
        Tower_Angle = target.transform.position.y;
        Burning.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (hp < 0 )
        {
            if (isDead == false)
            {
                tower.GetComponentInChildren<Rigidbody>().AddForce(Vector3.up * 300, ForceMode.Impulse);
                tower.GetComponentInChildren<Rigidbody>().AddForce(new Vector3(Random.Range(-1,1), 0, Random.Range(-1,1)) * 100, ForceMode.Impulse);
                tower.GetComponentInChildren<Rigidbody>().AddForce(Vector3.down * 180, ForceMode.Force);
                agent.enabled = false;
                // tower.GetComponentInChildren<MeshCollider>().convex = true; ;
                tower.GetComponentInChildren<Rigidbody>().useGravity = true;
                // tower.transform.Rotate(new Vector3(Random.value,0,0) * 5);
                isDead = true;
                Burning.SetActive(true);
            }
          
        }
        else
        {
            reloadtimer -= Time.deltaTime;
            if (Vector3.Distance(transform.position, target.transform.position) < 5000 && hp >= 0)
            {
                agent.SetDestination(target.transform.position);
                agent.updateRotation = true;

            }
            if (Vector3.Distance(transform.position, target.transform.position) < 650)
            {
                tower.transform.LookAt(new Vector3(target.transform.position.x, target.transform.position.y + 12, target.transform.position.z));
                gun.transform.LookAt(new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z));
            }
            if (Vector3.Distance(transform.position, target.transform.position) < 280 && reloadtimer <= 0)
            {
                //gunPoint.transform.LookAt(target.transform.position);
                var shot = Instantiate(bullet, gunPoint.transform.position, gunPoint.transform.rotation);

                reloadtimer = 4.5f;
            }
        }

    }
}
