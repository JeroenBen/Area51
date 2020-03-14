using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class taperotatebounce : MonoBehaviour {
	Vector3 begin;
	float rotatespeed=90f, bounceperiod=2f, bounceheight=0.1f;
	// Use this for initialization
	void Start () {
		begin = transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.position = begin + new Vector3(0, bounceheight*Mathf.Sin(Time.realtimeSinceStartup * 2 * Mathf.PI / bounceperiod), 0);
		transform.rotation = Quaternion.Euler(0, Time.realtimeSinceStartup * rotatespeed, 0);
	}
}
