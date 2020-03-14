using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character {
    public float walkspeed, runspeed, maxaboveground,
        minairheight, slopeCorrection, airspeed, jumpforce, maxjumptime, jumpStart, toosteep=1000.0f, sphereCastRadius;

    public static Player main;
    public GameObject deathScreen, winScreen;
    public GameObject curItem;
    public Transform playerCamera;
    public override State ReturnHomeState() {
        return new PlayerGround(this);
    }

    public void Win() {
        if(!(State is PlayerDied)) {
            SetState(new PlayerWon(this));
        }
    }
    public override void ChangeHealth(int amount) {
        if (Health != 0) {
            base.ChangeHealth(amount);
            if (Health == 0) {
                SetState(new PlayerDied(this));
            }
        }

    }
    public void FireWeapon() {
        if (curItem!=null && !GetComponent<Inventory>().inventoryUI.gameObject.activeSelf) {
            Weapon weapon = curItem.GetComponent<Weapon>();
            if (weapon != null) weapon.Fire();
        } 
        

    }

    public void move(float speed, Vector3 up, bool noVy) {
        float angle = Vector3.Angle(Vector3.up, up);
        if (angle>toosteep) {

            return;
        }
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        //Corrects the Vector2, so it always has a magnitude of 1
        if (input.magnitude >= 1) {
            input = input.normalized;
        }
        

        // Changes the relative motion vector to a global motion vector
        input = Quaternion.Euler(0, 0, -transform.eulerAngles.y) * input;
        input *= speed;
        Vector3 velocity = Vector3.Cross(up, new Vector3(-input.y, 0, input.x));
        Vector3 curVelocity = GetComponent<Rigidbody>().velocity;
        if (noVy)
        {
            velocity = new Vector3(velocity.x, curVelocity.y, velocity.z);
        }
        GetComponent<Rigidbody>().velocity = velocity;
    }

    public object GetRaycastHit(float maxDistance) {
        RaycastHit hit;
        if(Physics.SphereCast(transform.position+Vector3.up*sphereCastRadius, sphereCastRadius, transform.TransformDirection(Vector3.down), out hit, GetHeight() / 2 + maxDistance)) {
            return hit;
        }
        return false;
    }



    public object GetRaycastHitAir() {
        return GetRaycastHit(minairheight);
    }

    public object GetRaycastHitGround() {
        return GetRaycastHit(maxaboveground);
    }

    public float GetHeight() {
        return GetComponent<Collider>().bounds.size.y;
    }

    public override void InitCharacter()
    {
        main = this;
    }
}
