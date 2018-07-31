using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour {

    private float timerF;
    private int timerInt;
    public GameObject bullet;
    private Quaternion qrotation;

    [SerializeField]
    private Transform _destination;

    private NavMeshAgent _Navmesh;

	// Use this for initialization
	void Start () {
        _Navmesh = this.GetComponent<NavMeshAgent>();
        SetDestination();
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
	void Update () {

        SetDestination();

        qrotation = this.transform.rotation;

        timerF = timerF + Time.deltaTime;
        timerInt = Mathf.RoundToInt(timerF);

        if(timerInt == 2)
        {
            Instantiate(bullet, this.transform.position, qrotation);
        }

	}
}
