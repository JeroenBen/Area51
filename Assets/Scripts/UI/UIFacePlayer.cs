using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFacePlayer : MonoBehaviour {

	public float facing = 1;
	// Update is called once per frame
	void Update () {
		transform.rotation = Quaternion.LookRotation(facing*(LevelManager.Instance.Player.playerCamera.position - transform.position), Vector3.up);
	}
}
