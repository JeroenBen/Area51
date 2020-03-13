using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAir : State {
    public Player player;

    public PlayerAir(Player player) : base(player) {
        this.player = player;
    }

    public override void OnStateExit() {
        base.OnStateExit();
    }

    bool OnGround(object hit) {
        return hit.GetType() == typeof(RaycastHit);
    }

    public override void Tick() {
        object hit = player.GetRaycastHitAir();

        player.move(player.airspeed, Vector3.up, true);
        if(OnGround(hit)) {
            character.SetState(new PlayerGround(player));
        }
        if (Input.GetButton("Fire")) {
            player.FireWeapon();
        }
    }
}