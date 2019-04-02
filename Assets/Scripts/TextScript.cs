using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextScript : MonoBehaviour {
    RectTransform a ;
    public Text te;
    float kek;
    // Use this for initialization
    void Start () {
		a = te.GetComponent<RectTransform>();
       
        
    }
	
	// Update is called once per frame
	void Update () {
        
         kek += 40*Time.deltaTime;

        // a.offsetMin = new Vector2(a.offsetMin.x,0);
        a.offsetMax = new Vector2(a.offsetMax.x, kek);
        
    }

   
    
}
