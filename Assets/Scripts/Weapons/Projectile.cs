using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
	public float lifetime;
	public int damage;
	public bool destroyOnCharacterHit, destroyOnAnyHit;
	public Vector3 start;
	// Use this for initialization
	void Start () {
		start = transform.position;
		StartCoroutine(WaitandDestroy(lifetime));
	}
	
	public virtual void End() {
		Destroy(gameObject);
	}
	IEnumerator WaitandDestroy(float wait) {
		yield return new WaitForSeconds(wait);
		End();
	}
	// Update is called once per frame
	public virtual void FixedUpdate () {
		
	}
	public virtual void CharacterHit(Character character) {
		character.ChangeHealth(-damage);
		if (character is Enemy) {
			if (!(character.State is FollowPlayer)&& !(character.State is EnemyDead)) {
				character.SetState(new Investigate((Enemy) character, start));
			}
		}
		if (destroyOnCharacterHit) {
			End();
		}
		Physics.IgnoreCollision(GetComponent<Collider>(), character.GetComponent<Collider>());
	}
	public void OnCollisionEnter(Collision collision) {
		Character character = collision.gameObject.GetComponent<Character>();
		if (character != null) {
			CharacterHit(character);
		} else if (destroyOnAnyHit) {
			End();
		}
	}
}
