using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGround : State {
    // This is the default state on the ground. The player can move, jump, and when the player leaves the ground, the state gets set to PlayerAir
    public Player player;
    public int jumpTimer;
    public Vector3 normal = Vector3.up;

    public PlayerGround(Player player) : base(player) {
        this.player = player;
    }

    public override void OnStateEnter() {
        jumpTimer = 0;
    }

    void SlopeCorrection(float distance, Vector3 normal) {
        player.GetComponent<Rigidbody>().AddForce(-1 * normal * player.slopeCorrection * distance, ForceMode.Acceleration);
    }

    bool OnGround(object hit) {
        return hit.GetType() == typeof(RaycastHit);
    }

    public override void Tick() {
        object hit = player.GetRaycastHitGround();

        if(hit.GetType() == typeof(RaycastHit)) { 
            normal = ((RaycastHit)hit).normal;
        }

        if (!OnGround(hit))
        {
            character.SetState(new PlayerAir(player));
        }
        if (Input.GetButton("Run")) {
            player.move(player.runspeed, normal, false);

        } else {
            player.move(player.walkspeed, normal,false);
        }

        float angle = Vector3.Angle(Vector3.up, normal);
        if ((angle < player.toosteep) && Input.GetButton("Jump") && jumpTimer*Time.deltaTime>= player.jumpStart) {
            player.SetState(new PlayerJump(player));
        }
        if (Input.GetButton("Fire")) {
            player.FireWeapon();
        }
        jumpTimer++;
    }

}