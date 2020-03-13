using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : State {
    private int timer = 0;
    public Player player;

    public PlayerJump(Player player) : base(player) {
        this.player = player;
    }

    public override void OnStateEnter() {
        Vector3 velocity = player.GetComponent<Rigidbody>().velocity;
        velocity.y = 0;
        player.GetComponent<Rigidbody>().velocity = velocity;
        player.GetComponent<Rigidbody>().AddForce(Vector3.up * player.jumpforce);
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
        if(!OnGround(hit)) {
            character.SetState(new PlayerAir(player));
        } else if(timer > player.maxjumptime) {
            character.SetState(new PlayerGround(player));
        }
        if (Input.GetButton("Fire")) {
            player.FireWeapon();
        }
        timer++;
    }
}
