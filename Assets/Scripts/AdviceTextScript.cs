using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdviceTextScript : MonoBehaviour
{
    public UnityEngine.UI.Text adviceText;
    public TowerScript tower;
    // Start is called before the first frame update
    void Start()
    {
        adviceText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
