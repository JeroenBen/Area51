using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerWon : State {
    public Player player;

    public PlayerWon(Player player) : base(player) {
        this.player = player;
    }

    public override void OnStateEnter() {

        // Unlock the player
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        player.GetComponent<PlayerLook>().mouseSensitivity = 0;
        player.winScreen.SetActive(true);
        player.winScreen.GetComponent<DarkenScreen>().FadeToAlpha(0.9f, 5);

    }



    public override void Tick() {
    }
}
