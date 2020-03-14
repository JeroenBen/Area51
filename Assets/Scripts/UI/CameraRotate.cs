using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CameraRotate : MonoBehaviour {
    public float maxMotionAngle, period, maxDistance, viewAngle;
    public bool SawPlayer;
    [SerializeField] private UnityEvent onPlayerSee;
    private void Start() {
        SawPlayer = false;
    }
  
    // Check if player is in view of the camera, with a raycasting check
    public bool SeesPlayer() {
        Player player = LevelManager.Instance.Player;
        Vector3 toPlayer = (player.transform.position - transform.position);
        if (toPlayer.magnitude <= maxDistance && Vector3.Angle(transform.forward, toPlayer) < viewAngle) {
            if (Physics.Raycast(transform.position, toPlayer, toPlayer.magnitude)) {
                return true;
            }
        }
        return false;
    }

    void FixedUpdate() {
        if (SeesPlayer()) {
            SawPlayer = true;
            onPlayerSee.Invoke();
        }
        transform.localRotation = Quaternion.Euler(0, -90 + Mathf.Sin(Time.realtimeSinceStartup * 2 * Mathf.PI / period) * maxMotionAngle, 0);
    }
}
