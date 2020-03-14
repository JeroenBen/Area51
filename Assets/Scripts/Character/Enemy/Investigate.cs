using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Investigate : State
{
	public Enemy enemy;
	public NavMeshAgent navMeshAgent;
	private Vector3 goTo;
	public Investigate(Enemy enemy, Vector3 goTo) : base(enemy) {
		this.enemy = enemy;
		this.goTo = goTo;
	}

	public override void OnStateEnter() {
		enemy.ResetWeaponRotation();
		enemy.GetComponent<Renderer>().material.color = Color.Lerp(enemy.patrollingColor, enemy.followColor, 0.35f); ;
		navMeshAgent = enemy.GetComponent<NavMeshAgent>();
		navMeshAgent.stoppingDistance = 0.1f;
		navMeshAgent.SetDestination(goTo);

	}

	public override void OnStateExit() {
	}

	public override void Tick() {

		if (enemy.SeesPlayer()) {
			enemy.SetState(new FollowPlayer(enemy));
		} else if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance) {
			enemy.SetState(new LookingAround(enemy));
		}

	}




}
