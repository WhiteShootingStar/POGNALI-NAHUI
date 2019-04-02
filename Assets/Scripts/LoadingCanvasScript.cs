using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingCanvasScript : MonoBehaviour
{
    public GameObject Canvas;
    public Text text;
    public Image Slider;
  
    // Start is called before the first frame update
    void Start()
    {
        Canvas.SetActive(true);
        Slider.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
