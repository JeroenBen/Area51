using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyDead : State {
	public Enemy enemy;
	public EnemyDead(Enemy enemy) : base(enemy) {
			this.enemy = enemy;
	}
    public void drop(Item item) {
        Player player = LevelManager.Instance.Player;
        GameObject.Instantiate(Resources.Load<GameObject>("PrefabsWorld/" + item.title), enemy.transform.position, enemy.transform.rotation);

    }
    public override void OnStateEnter() {
        Item item = ItemDatabase.main.GetItem(enemy.curWeapon.GetComponent<Weapon>().itemid);
        drop(item);
		LevelManager.Instance.enemies.Remove(enemy);
		enemy.destroySelfAfter(5);
		enemy.GetComponent<NavMeshAgent>().enabled = false;
        enemy.curWeapon.SetActive(false);
        Rigidbody rigidbody = enemy.GetComponent<Rigidbody>();
		rigidbody.isKinematic = false;
		rigidbody.AddTorque(enemy.transform.forward * 10f);
	}

	public override void Tick() {
		
	}




}
