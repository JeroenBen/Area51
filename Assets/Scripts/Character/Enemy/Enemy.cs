using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Enemy : Character {
	public static List<Enemy> enemies = new List<Enemy>();
	public float detectRadius, normalStoppingDistance, viewAngle, giveUpTime, shootingRadius, lookAroundSpeed, lookAroundTime;
	public Color followColor, patrollingColor;
	public List<Transform> patrolPoints;
	public float accel;
	public GameObject curWeapon;
	public Quaternion weaponRotation;
	public override void InitCharacter() {

		NavMeshAgent navMeshAgent = GetComponent<NavMeshAgent>();
		navMeshAgent.autoBraking = true;
		weaponRotation = curWeapon.transform.localRotation;
		enemies.Add(this);
	}

	public override void ChangeHealth(int amount) {
		if (health != 0) {
			health = Mathf.Clamp(health + amount, 0, maxHealth);
			if (health == 0) {
				SetState(new EnemyDead(this));
			}
			
		}
		

	}

	public void FireWeapon() {
		if (curWeapon != null) {
			Weapon weapon = curWeapon.GetComponent<Weapon>();
			if (weapon != null) weapon.Fire();

		}


	}
	public bool PointGunAtPlayer() {
		Vector3 dir = (LevelManager.Instance.Player.transform.position- curWeapon.transform.position);
		float distance = dir.magnitude;
		if (distance>shootingRadius) {
			return false;
		}
		Ray ray = new Ray(curWeapon.transform.position, dir);
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit, distance+1)) {

			if (hit.transform.GetComponent<Player>() != null) {
				curWeapon.transform.rotation = weaponRotation*Quaternion.LookRotation(dir.normalized, Vector3.up);
				return true; ;
			}
			else {
				print("Something is between my gun and the player");
				return false;
			}

		}
		curWeapon.transform.rotation = weaponRotation * Quaternion.LookRotation(dir.normalized, Vector3.up);
		print("noRaycast");
		return true;
			
		
	}
	public void ResetWeaponRotation() {
		curWeapon.transform.localRotation = weaponRotation;
	}

	IEnumerator WaitandDestroy(float wait) {
		yield return new WaitForSeconds(wait);
		Destroy(gameObject);
	}
	public void destroySelfAfter(float wait) {
		StartCoroutine(WaitandDestroy(wait));
	}

	public bool SeesPlayer() {
		Player player = LevelManager.Instance.Player;
		Vector3 dir = (player.transform.position - transform.position);
		if (dir.magnitude <= detectRadius && Vector3.Angle(transform.forward, dir) < viewAngle) {
			dir = dir.normalized;
			Ray ray = new Ray(transform.position+dir, dir);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit,detectRadius)) {

				if (hit.transform.GetComponent<Player>() != null) return true;

			}
		}
		return false;
	}
	public void LookTowardsPlayer() {
		transform.LookAt(LevelManager.Instance.Player.transform, transform.up);
	}


	public override State ReturnHomeState() {
		return new Patrolling(this);
	}

}
