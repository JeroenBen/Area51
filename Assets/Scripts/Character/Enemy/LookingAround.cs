using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LookingAround: State {
	public Enemy enemy;
	NavMeshAgent navMeshAgent;

	public int ticksNotSeen = 0;
	public LookingAround(Enemy enemy) : base(enemy) {
			this.enemy = enemy;
	}

	public override void OnStateEnter() {
		enemy.ResetWeaponRotation();
		enemy.GetComponent<Renderer>().material.color = Color.Lerp(enemy.patrollingColor, enemy.followColor, 0.5f);
		navMeshAgent = enemy.GetComponent<NavMeshAgent>();
		navMeshAgent.updateRotation = false;

	}

	public override void OnStateExit() {
		navMeshAgent.updateRotation = true;
	}

	public override void Tick() {
		
		if (enemy.SeesPlayer()) {
			enemy.SetState(new FollowPlayer(enemy));
		} else {
			ticksNotSeen++;
			if (ticksNotSeen* Time.fixedDeltaTime>=enemy.lookAroundTime) {
				enemy.SetState(new Patrolling(enemy));
			}
			enemy.transform.rotation *= Quaternion.AngleAxis(enemy.lookAroundSpeed * Time.fixedDeltaTime, enemy.transform.up);
		}

	}




}
