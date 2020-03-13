using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSlider : MonoBehaviour {
	public Character character;

	
	// Update is called once per frame
	void Update () {
		GetComponent<Slider>().value = character.Health;

	}
}
