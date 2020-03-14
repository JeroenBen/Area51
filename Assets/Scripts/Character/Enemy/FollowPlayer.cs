using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowPlayer : State {
	public Enemy enemy;
	public int ticksNotSeen = 0;
	public FollowPlayer(Enemy enemy) : base(enemy) {
			this.enemy = enemy;
	}

	public override void OnStateEnter() {
		enemy.GetComponent<Renderer>().material.color = enemy.followColor;
	}
	public override void Tick() {
		NavMeshAgent navMeshAgent = enemy.GetComponent<NavMeshAgent>();

		if (enemy.SeesPlayer()) {
			if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance) {
				navMeshAgent.updateRotation = false;
				enemy.LookTowardsPlayer();



			} else {
				navMeshAgent.updateRotation = true;
				
			}
			if (enemy.PointGunAtPlayer()) {
				enemy.FireWeapon();
			}
			navMeshAgent.SetDestination(LevelManager.Instance.Player.transform.position);
			navMeshAgent.stoppingDistance = enemy.normalStoppingDistance;
		} else {
			navMeshAgent.updateRotation = true;
			navMeshAgent.stoppingDistance = 0.2f;
			if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance) {
				enemy.SetState(new LookingAround(enemy));
			}

			if (ticksNotSeen*Time.fixedDeltaTime>enemy.giveUpTime) {
				enemy.SetState(new Patrolling(enemy));
			}
			
		}
		
		
	}




}
