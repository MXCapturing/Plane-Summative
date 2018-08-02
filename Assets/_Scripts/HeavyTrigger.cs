using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyTrigger : MonoBehaviour {

    public GameObject Blimp;

    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "BaseCube")
        {
            BaseScript.instance.health -= 10;
            Destroy(Blimp);
        }
    }
}
