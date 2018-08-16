using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosions : MonoBehaviour {

    public AudioClip explosion;
    public AudioSource expSource;

    // Use this for initialization
    void Start () {
        expSource.clip = explosion;
        expSource.Play();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
