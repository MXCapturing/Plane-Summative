using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicScript : MonoBehaviour {

    public AudioSource musicPlayer;
    public AudioClip music;

    // Use this for initialization
    void Start () {
        musicPlayer.clip = music;
        musicPlayer.Play();
    }
	
}
