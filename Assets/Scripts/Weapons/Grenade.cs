using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : Projectile {
	public GameObject explosion;
	// Use this for initialization
	public override void End() {
		Instantiate(explosion, transform.position, Random.rotation);
		base.End();
	}

}
