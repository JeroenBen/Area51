using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSounds : MonoBehaviour
{
	public List<AudioClip> sounds;
	public AudioSource source;
	public int randomSpread, wait;
	// Use this for initialization
	int timer;
	void Start() {
		timer = (int)(Random.value * randomSpread);

	}
	// Update is called once per frame
	void FixedUpdate() {
		if (timer <= 0 && sounds.Count!=0) {
			source.PlayOneShot(sounds[Random.Range(0, sounds.Count)]);

			timer = wait + (int)(Random.value * randomSpread);
			print(timer);
		}



		timer--;
	}
}
