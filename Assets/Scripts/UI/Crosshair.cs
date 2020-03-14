using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crosshair : MonoBehaviour {
	public Color interactColor, normalColor;

	
	// Update is called once per frame
	void Update () {
		Player player = LevelManager.Instance.Player;
		if (player.GetComponent<PlayerInteract>().canInteract) {
			GetComponent<Image>().color = interactColor;
		} else {
			GetComponent<Image>().color = normalColor;
		}
	}
}
