using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : Projectile {
	public float explosionRate, explosionForce;
	// Update is called once per frame
	public override void FixedUpdate () {
		transform.localScale += Vector3.one * Time.fixedDeltaTime * explosionRate;
	}
	public override void CharacterHit(Character character) {
		base.CharacterHit(character);
		Rigidbody rigidbody = character.GetComponent<Rigidbody>();
		if (rigidbody!=null) {
			rigidbody.AddForce((character.transform.position- transform.position).normalized * explosionForce, ForceMode.Impulse);
		}
	}
}
