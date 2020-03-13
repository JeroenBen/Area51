using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lift : MonoBehaviour {
	public WinCondition winCondition;
	private void OnTriggerEnter(Collider other) {
		print("Something Entered");
		if (other.gameObject.GetComponent<Player>() != null) {
			CheckWincondition();
		}
	}

	private void CheckWincondition() {
		if (winCondition.PlayerWins()) {
			LevelManager.Instance.Player.Win();
		}
	}
}
