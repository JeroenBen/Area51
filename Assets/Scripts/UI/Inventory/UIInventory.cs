using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventory : MonoBehaviour
{
    public List<UIItem> uIItems = new List<UIItem>();
    public GameObject slotPrefab;
    public Transform slotPanel;
    public GameObject hand;
    public int aantalVakjes = 24;

    private void Awake() {
        for (int i = 0; i<aantalVakjes; i++) {
            GameObject instance = Instantiate(slotPrefab);
            instance.transform.SetParent(slotPanel);
            uIItems.Add(instance.GetComponentInChildren<UIItem>());
        }
        gameObject.SetActive(false);
    }

    // update wat in een vakje zichtbaar is, met id van het vakje (positie)
    public void UpdateVakje(int idVakje, Item item) {
        uIItems[idVakje].UpdateItem(item);
    }
    // voeg een item toe in het eerste lege vakje
    public void AddItem(Item item) {
        HandUIItem handUI = hand.GetComponent<HandUIItem>();
        if (handUI.item == null) {
            handUI.UpdateHand(item);
            handUI.UpdateItem(item);
        }
        else {
            UpdateVakje(uIItems.FindIndex(i => i.item == null), item);
        }

    }
    public void RemoveItem(Item item) {
        UpdateVakje(uIItems.FindIndex(i => i.item == item), null);
    }

}
