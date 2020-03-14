using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {
	public Transform spawn;
	public GameObject projectile;
	public AudioSource audioSource;
	public AudioClip sound;
	public float speed;
	public float firerate=10000;
	private int timer=0;
    public int itemid;
	public bool isPlayerWeapon = false;

	// Use this for initialization
	void Start () {
		timer = 0;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		timer++;
	}

	public virtual void Fire() {
		if ((float)timer*Time.fixedDeltaTime < 1.0f/firerate) {
			return;
		}
		if (audioSource != null) {
			audioSource.PlayOneShot(sound,0.2f);
		}
		timer = 0;
		GameObject bullet = Instantiate(projectile);
		bullet.transform.position = spawn.position;
		bullet.transform.rotation = spawn.rotation* bullet.transform.rotation;
		bullet.GetComponent<Rigidbody>().AddForce(spawn.forward * speed,ForceMode.VelocityChange);
		if (isPlayerWeapon) {
			Physics.IgnoreCollision(bullet.GetComponent<Collider>(), LevelManager.Instance.Player.GetComponent<Collider>());
		}
		
	}
}
