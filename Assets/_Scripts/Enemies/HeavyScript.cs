using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class HeavyScript : MonoBehaviour {
    private Quaternion qrotation;

    public int hp;
    public Image hpBar;

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
        hp = GetComponent<Damageable>().currentHP;
        hpBar.fillAmount = 0.02f * hp;
    }
}
