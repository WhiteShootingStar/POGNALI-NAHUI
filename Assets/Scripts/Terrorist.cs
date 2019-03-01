using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Terrorist : MonoBehaviour
{
    public GameObject tank, rocket_ter, rocket_point;
    NavMeshAgent agent;
    Animator anim;

    float reloadtimer = 4.5f;
    public int hp = 120;
    public bool roof;
    float prepTime = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        anim.SetFloat("Distance", Vector3.Distance(transform.position, tank.transform.position));
        //    print(Vector3.Distance(transform.position, tank.transform.position));

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
            agent.destination = tank.transform.position;
            reloadtimer -= Time.deltaTime;
            anim.SetFloat("Distance", Vector3.Distance(transform.position, tank.transform.position));
          

            if (Vector3.Distance(transform.position, tank.transform.position) <= 200)
            {
                transform.LookAt(tank.transform.position);
                if (reloadtimer < 0)
                {

                    reloadtimer = 4.5f;
                    Invoke("instR", 0.9f);

                }
            }
        }
    }
    void instR()
    {
        Instantiate(rocket_ter, rocket_point.transform.position, rocket_point.transform.rotation);
    }

}

