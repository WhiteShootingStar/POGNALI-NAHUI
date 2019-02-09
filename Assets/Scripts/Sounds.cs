using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour {
    public AudioClip[] clip;
    AudioSource sour;
    private AudioClip cl;
    float length = 0f;
    // Use this for initialization
    void Start () {
        sour =gameObject.GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        if (length <= 0)
        {
            int index = Random.Range(0, clip.Length);
           
            cl = clip[index];
            sour.clip = cl;
            sour.Play();
            length = cl.length;
        }
        length -= Time.deltaTime;
    }
}
