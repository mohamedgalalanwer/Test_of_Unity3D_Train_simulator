using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gyri : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Input.gyro.enabled = true;

	}
	
	// Update is called once per frame
	void Update () {
        Quaternion atl = Input.gyro.attitude;
        atl=Quaternion.Euler(90f,0f,0f)*new Quaternion(atl.x,atl.y,-atl.z,-atl.w);
        transform.rotation = atl;
	}
}
