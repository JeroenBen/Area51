using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour {
    [SerializeField] private UnityEvent onInteract;

    public void interact() {
        onInteract.Invoke();
    }
    public void destroyself() {
        Destroy(gameObject);
    }

    public void giveItem(int index) {
        LevelManager.Instance.Player.GetComponent<Inventory>().GiveItem(index);
    }
}
