using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour {
    public string mouseXInputName, mouseYInputName;
    public float normalmouseSensitivity, mouseSensitivity, fovNormal, fovRun, fovP;
    public Transform playerCamera;

    private float xAxisClamp = 0.0f;

    private void Awake() {
        Cursor.lockState = CursorLockMode.Locked;
        playerCamera.GetComponent<Camera>().fieldOfView = fovNormal;
    }

    public void lockcamera(bool locked) {
        if(locked) {
            mouseSensitivity = 0;
        } else {
            mouseSensitivity = normalmouseSensitivity;
        }
    }
    private void FixedUpdate() {
        CameraRotation();

        //Sets the field of view bigger when the player is running
        float fov = playerCamera.GetComponent<Camera>().fieldOfView;
        float fovTarget = Input.GetButton("Run") ? fovRun : fovNormal;
        playerCamera.GetComponent<Camera>().fieldOfView += (fovTarget-fov) * fovP;

    }

    private void CameraRotation() {
        float mouseX = Input.GetAxis(mouseXInputName) * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis(mouseYInputName) * mouseSensitivity * Time.deltaTime;

        xAxisClamp += mouseY;

        if(xAxisClamp > 90.0f) {
            xAxisClamp = 90.0f;
            mouseY = 0.0f;
            ClampXAxisRotationToValue(270.0f);
        } else if(xAxisClamp < -90.0f) {
            xAxisClamp = -90.0f;
            mouseY = 0.0f;
            ClampXAxisRotationToValue(90.0f);
        }

        playerCamera.Rotate(Vector3.left * mouseY);
        transform.Rotate(Vector3.up * mouseX);
    }

    private void ClampXAxisRotationToValue(float value) {
        Vector3 eulerRotation = playerCamera.eulerAngles;
        eulerRotation.x = value;
        playerCamera.eulerAngles = eulerRotation;
    }
}