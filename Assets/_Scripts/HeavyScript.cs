using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HeavyScript : MonoBehaviour {

    private Quaternion qrotation;

    [SerializeField]
    private GameObject _destination;

    private NavMeshAgent _Navmesh;

    // Use this for initialization
    void Start () {
        _Navmesh = this.GetComponent<NavMeshAgent>();
        SetDestination();
        _destination = GameObject.Find("BaseCube");
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
    void Update () {
        SetDestination();
	}
}
