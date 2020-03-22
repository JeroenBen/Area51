using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lift : MonoBehaviour {
	public WinCondition winCondition;
	public GameObject doorL, doorR;
	public Vector3 beginL, beginR;
	public float distance;
	private void OnTriggerEnter(Collider other) {
		print("Something Entered");
		if (other.gameObject.GetComponent<Player>() != null) {

			CheckWincondition();
		}
	}
	void Start() {
		beginL = doorL.transform.position;
		beginR = doorR.transform.position;
	}
	private void CheckWincondition() {
		if (winCondition == null || winCondition.PlayerWins()) {
			LevelManager.Instance.Player.Win();
		}
	}

	void FixedUpdate() {
		bool angry = false;
		if (LevelManager.Instance.enemies != null) {
			angry = LevelManager.Instance.enemies.Exists(x => x.State is FollowPlayer);
		}
		if (angry) {
			//print("ENEMY IS ANGRY");
		}
		MoveDoors(angry);
	}

	void MoveDoors(bool a) {
		float dx = a ? distance: 0;
		doorL.transform.position = beginL - dx * doorL.transform.right;
		doorR.transform.position = beginR + dx * doorR.transform.right;

	}
}
