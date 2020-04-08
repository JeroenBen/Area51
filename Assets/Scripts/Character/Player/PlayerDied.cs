using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDied : State {
    public Player player;

    public PlayerDied(Player player) : base(player) {
        this.player = player;
    }

    public override void OnStateEnter() {
        player.GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
        Rigidbody m_Rigidbody = player.GetComponent<Rigidbody>();
        // Unlock the player
        Time.timeScale = 0.5f;
        m_Rigidbody.constraints = RigidbodyConstraints.None;
        m_Rigidbody.AddTorque(player.transform.forward * 10f);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        player.GetComponent<PlayerLook>().mouseSensitivity = 0;
        player.deathScreen.SetActive(true);
        player.deathScreen.GetComponent<DarkenScreen>().FadeToAlpha(0.9f, 5);

    }

    public override void OnStateExit() {
        base.OnStateExit();
    }


    public override void Tick() {
    }
}
