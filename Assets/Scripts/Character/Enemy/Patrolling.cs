using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrolling: State {
	public Enemy enemy;
	public NavMeshAgent navMeshAgent;
	public int patrolIndex=0;
	public Patrolling(Enemy enemy) : base(enemy) {
			this.enemy = enemy;
	}

	public override void OnStateEnter() {
		enemy.ResetWeaponRotation();
		enemy.GetComponent<Renderer>().material.color = enemy.patrollingColor;
		navMeshAgent = enemy.GetComponent<NavMeshAgent>();
		navMeshAgent.stoppingDistance = 0.1f;
		navMeshAgent.SetDestination(enemy.patrolPoints[0].position);

	}

	public override void OnStateExit() {
	}

	public override void Tick() {
		
		if (enemy.SeesPlayer()) {
			enemy.SetState(new FollowPlayer(enemy));
		} else {
			if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance) {
				patrolIndex = (patrolIndex + 1) % enemy.patrolPoints.Count;
				navMeshAgent.SetDestination(enemy.patrolPoints[patrolIndex].position);
			}
			
		}

	}




}
