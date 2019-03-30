using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerScript : MonoBehaviour
{
    public float hp = 150;
   public Rigidbody turret_rigidbody;
    public Collider col;
    // Start is called before the first frame update
    void Start()
    {
        hp = 150;
        turret_rigidbody = GetComponent<Rigidbody>();
        col.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
