using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class MediumsScript : MonoBehaviour {


    private float timerF;
    private int timerInt;
    public GameObject bullet;
    private Quaternion qrotation;

    public int hp;
    public Image hpBar;

[SerializeField]
    private GameObject _destination;

    private NavMeshAgent _Navmesh;

    // Use this for initialization
    void Start()
    {
        _Navmesh = this.GetComponent<NavMeshAgent>();
        SetDestination();
        InvokeRepeating("Shooting", 2f, 2f);
        _destination = GameObject.Find("Player");
    }

    void SetDestination()
    {
        if (_destination != null)
        {
            Vector3 targetVector = _destination.transform.position;
            _Navmesh.SetDestination(targetVector);
        }
    }

    // Update is called once per frame
    void Update()
    {
        SetDestination();
        hp = GetComponent<Damageable>().currentHP;
        hpBar.fillAmount = 0.034f * hp;

        if (GameManager.instance.paused == true || GameManager.instance.alive == false)
        {
            _Navmesh.isStopped = true;
        }
        if (GameManager.instance.paused == false && GameManager.instance.alive == true)
        {
            _Navmesh.isStopped = false;
        }
    }

    private void Shooting()
    {
        qrotation = this.transform.rotation;
        Instantiate(bullet, this.transform.position, qrotation);
    }
}
