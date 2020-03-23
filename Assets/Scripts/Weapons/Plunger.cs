using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plunger : Weapon {

    [SerializeField] private float range, pullforce;
    public Transform pullposition;

    public override void Fire() {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -transform.up, out hit, range)) {
            Rigidbody rigidbody = hit.transform.GetComponent<Rigidbody>();
            if (rigidbody != null) {
                print("pulling");
                rigidbody.AddForce((pullposition.position - hit.transform.position) * pullforce, ForceMode.Acceleration);
            }
        }
    }
}
