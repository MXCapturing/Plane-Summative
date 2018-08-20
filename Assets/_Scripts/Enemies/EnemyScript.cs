using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour {

    private float timerF;
    private int timerInt;
    public GameObject bullet;
    private Quaternion qrotation;

    public AudioSource soundMaker;
    public AudioClip sound;

    [SerializeField]
    private GameObject _destination;

    private NavMeshAgent _Navmesh;

    // Use this for initialization
    void Start () {
        _Navmesh = this.GetComponent<NavMeshAgent>();
        SetDestination();
        InvokeRepeating("Shooting", 2f, 2f);
        if (PlayerPrefs.GetInt("Player") == 1)
        {
            _destination = GameObject.Find("Player(Clone)");
        }
        if (PlayerPrefs.GetInt("Player") == 2)
        {
            _destination = GameObject.Find("Player2(Clone)");
        }
        if (PlayerPrefs.GetInt("Player") == 3)
        {
            _destination = GameObject.Find("Player3(Clone)");
        }

        soundMaker.clip = sound;
        _Navmesh.speed += GameManager.instance.speedPoints;
    }

    void SetDestination()
    {
        if(_destination != null)
        {
            Vector3 targetVector = _destination.transform.position;
            _Navmesh.SetDestination(targetVector);
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        SetDestination();

        if(GameManager.instance.paused == true || GameManager.instance.alive == false)
        {
            _Navmesh.isStopped = true;
        }
        if(GameManager.instance.paused == false && GameManager.instance.alive == true)
        {
            _Navmesh.isStopped = false;
        }  
    }

    private void Shooting()
    {
        soundMaker.Play();
        qrotation = this.transform.rotation;
        Instantiate(bullet, this.transform.position, qrotation);
    }
}
