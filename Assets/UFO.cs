using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFO : MonoBehaviour {
	public WinCondition winCondition;
	// Use this for initialization
	public void Wins() {
		if(winCondition.PlayerWins()) {
			LevelManager.Instance.Player.Win();
		}
	}
}
