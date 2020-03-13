using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour {
    private const float range = 5.0f;
    public bool canInteract;
    [SerializeField] private Camera playerCamera;

    void FixedUpdate() {
        Vector3 cameraCenter = playerCamera.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, playerCamera.nearClipPlane));
        RaycastHit hit;
        canInteract = false;
        if (Physics.Raycast(cameraCenter, playerCamera.transform.forward, out hit, range)) {
            GameObject obj = hit.transform.gameObject;
            Interactable interactable = obj.GetComponent<Interactable>();
            if (interactable != null) {
                canInteract = true;
                if (Input.GetButtonDown("Interact")) {
                    interactable.interact();
                }

            }
        } 

    }
}
