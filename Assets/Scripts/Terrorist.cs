using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Terrorist : MonoBehaviour
{
    public GameObject rocket_ter, rocket_point, rocket_point_stand;

    NavMeshAgent agent;
    Animator anim;
    public TankMovingscript Tank;
    float reloadtimer = 4.5f;
   public  GameObject target;
    public int hp = 120;
    public bool roof;
    float prepTime = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        reloadtimer = 4.5f;
        target = GameObject.FindGameObjectWithTag("Body");
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        anim.SetFloat("Distance", Vector3.Distance(transform.position, target.transform.position));
        anim.SetBool("IsWatchmen", roof);
        Tank = target.GetComponent<TankMovingscript>();
        //    print(Vector3.Distance(transform.position, tank.transform.position));
        //  tank = GameObject.FindGameObjectWithTag("Body");
    }

    // Update is called once per frame
    void Update()
    {
        //rocket_point.transform.rotation.eulerAngles.Set(0,0,0);

        if (hp <= 0)
        {
            agent.enabled = false;
            anim.SetTrigger("Dying");
            Destroy(gameObject, 4);

        }
        else
        {
            reloadtimer -= Time.deltaTime;
            anim.SetFloat("Distance", Vector3.Distance(transform.position, target.transform.position));
            if (roof == false)
            {
                agent.destination = target.transform.position;
                agent.updateRotation = true;


                
                if (Vector3.Distance(transform.position, target.transform.position) <= 200 && Tank.hp > 0)
                {
                   
                    transform.LookAt(target.transform.position);
                    rocket_point.transform.LookAt(target.transform.position );
                    if (reloadtimer < 0)
                    {
                       
                        reloadtimer = 4.5f;
                        Invoke("instR", 0.9f);

                    }
                }
            }
            else
            {


                if (Vector3.Distance(transform.position, target.transform.position) <= 800 && Tank.hp > 0)
                {
                    transform.LookAt(target.transform.position);


                    if (reloadtimer < 0)
                    {
                       
                        reloadtimer = 4.5f;
                        Invoke("instRStand", 0.9f);

                    }
                }
            }
        }
    }
    void instR()
    {
        //  rocket_point.transform.LookAt(Tank.transform.position);
        Instantiate(rocket_ter, rocket_point.transform.position, rocket_point.transform.rotation);
    }
    void instRStand()
    {
        rocket_point_stand.transform.LookAt(target.transform.position);
        var shot = rocket_ter;
       // shot.transform.Rotate(180, 0, 0);

        Instantiate(shot, rocket_point_stand.transform.position, rocket_point_stand.transform.rotation /** Quaternion.Euler(88f, 180f, 180f)*/);
    }

}

