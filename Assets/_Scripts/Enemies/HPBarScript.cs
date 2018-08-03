using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBarScript : MonoBehaviour {

    public Camera plCam;

	
	// Update is called once per frame
	void Update () {
        transform.LookAt(transform.position + plCam.transform.rotation * Vector3.back, plCam.transform.rotation * Vector3.up);
	}
}
