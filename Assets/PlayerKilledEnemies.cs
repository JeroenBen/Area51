using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKilledEnemies : WinCondition {
	public override bool PlayerWins() {
		return LevelManager.Instance.enemies.Count == 0;
	}

}
