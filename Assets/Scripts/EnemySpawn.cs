using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{   public EnemyTanKScript tank;
    public Terrorist terrorist,standingTerrorist;
    public List<GameObject> terroristSpawn ;
    public List<GameObject> tankSpawn;
    public List<GameObject> terroristIdleSpawn;
    // Start is called before the first frame update
    void Start()
    {
        for(int i =0; i < 15; i++)
        {
            var randomPoint = terroristSpawn[(int)(Random.Range(0, terroristSpawn.Count))];
            Instantiate(terrorist, randomPoint.transform.position, randomPoint.transform.rotation);
        }
        for (int i = 0; i < 5; i++)
        {
            var randomPoint = terroristIdleSpawn[(int)(Random.Range(0, terroristIdleSpawn.Count))];
          //  Instantiate(standingTerrorist, randomPoint.transform.position, randomPoint.transform.rotation);
          
            var randomTankPoint = tankSpawn[(int)(Random.Range(0, tankSpawn.Count))];
            Instantiate(tank, randomTankPoint.transform.position, randomTankPoint.transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
