using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class DontClick4 : MonoBehaviour {
	public VideoPlayer videoPlayer;
	public GameObject plaatjescherm;
	public GameObject videoscherm;

	void Update(){
		if (!videoPlayer.isPlaying && videoscherm.activeSelf){
			ClickScreen();
		}
	}
 
	//wat er gebeurt als je op het scherm clickt met een tap in je hand
	public void ClickScreen() {
		if (videoscherm.activeSelf){
			videoPlayer.Pause();
			videoscherm.SetActive(false);
			plaatjescherm.SetActive(true);
		}

		// als de speler de tape in handen heeft
		// ik weet niet hoe die heet
		// maar die check kan hier in
		else if (true) {
			Debug.Log("zet aan");

			plaatjescherm.SetActive(false);
			videoscherm.SetActive(true);
			videoPlayer.frame = 0;
			videoPlayer.Play();
		} 
	}

	
}
