using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movable : MonoBehaviour {
    private float dx = 0.0f;
    private float dy = 0.0f;
    private float dz = 0.0f;
    private float speed = 0.01f;
    private float minspeed = 0.005f;

    public void MoveToX(float dx) {
        this.dx += dx;
    }

    public void MoveToY(float dy) {
        this.dy += dy;
    }

    public void MoveToZ(float dz) {
        this.dz += dz;
    }

    public void SetSpeed(float speed) {
        this.speed = speed;
    }

    public void Update() {
        float ddx = 0, ddy = 0, ddz = 0;

        if(Mathf.Abs(this.dx) >= minspeed) {
            ddx = Mathf.Sign(this.dx) * Mathf.Max(this.minspeed, Mathf.Abs(this.dx) * this.speed);
        } else {
            ddx = this.dx;
        }
        if(Mathf.Abs(this.dy) >= minspeed) {
            ddy = Mathf.Sign(this.dy) * Mathf.Max(this.minspeed, Mathf.Abs(this.dy) * this.speed);
        } else {
            ddy = this.dy;
        }
        if(Mathf.Abs(this.dz) >= minspeed) {
            ddz = Mathf.Sign(this.dz) * Mathf.Max(this.minspeed, Mathf.Abs(this.dz) * this.speed);
        } else {
            ddz = this.dz;
        }

        this.dx -= ddx;
        this.dy -= ddy;
        this.dz -= ddz;

        Vector3 move = new Vector3(ddx, ddy, ddz);
        transform.position += move;
    }
}
