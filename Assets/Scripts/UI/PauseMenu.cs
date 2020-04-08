using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public static bool isPaused;
    public GameObject PauseMenuUI;
    public GameObject DeathScreen, winScreen;
    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape) && !DeathScreen.activeSelf && !winScreen.activeSelf) {
            isPaused = !isPaused;
            if (isPaused) {
                Pause();
            } else {
                Resume();
            }
        }
    }

    public void Resume() {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1.0f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void LoadMainMenu() {
        Time.timeScale = 1;
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }

    public void Restart() {
            int scene = SceneManager.GetActiveScene().buildIndex;
            Time.timeScale = 1;
            SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }

    public void LoadNextLevel() {
        int scene = SceneManager.GetActiveScene().buildIndex;
        Time.timeScale = 1;
        SceneManager.LoadScene(scene+1, LoadSceneMode.Single);
    }
    public void Pause() {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0.0f;
    }

    public void Quit() {
        Application.Quit();
    }
}
