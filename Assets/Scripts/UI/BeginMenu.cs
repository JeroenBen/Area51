using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeginMenu : MonoBehaviour {
	public GameObject options, mainMenu, levels;
	// Use this for initialization

	public void Options() {
		options.SetActive(true);
		mainMenu.SetActive(false);
	}

	public void Back() {
		levels.SetActive(false);
		options.SetActive(false);
		mainMenu.SetActive(true);
	}
	public void Levels() {
		levels.SetActive(true);
		mainMenu.SetActive(false);
	} 
	public void LoadNextLevel() {
		int scene = SceneManager.GetActiveScene().buildIndex;
		Time.timeScale = 1;
		SceneManager.LoadScene(scene + 1, LoadSceneMode.Single);
	}

	public void LoadLevel(int scene) {
		SceneManager.LoadScene(scene, LoadSceneMode.Single);
	}

		public void Quit() {
		Application.Quit();
	}
}
