using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> characterItems = new List<Item>();
    public List<int> beginItems;
    public ItemDatabase itemDatabase;
    public UIInventory inventoryUI;
    public GameObject DeathScreen;

    // voeg een item toe aan de lijst met items in je inventory
    public void GiveItem(int id) {
        Item toevoegen = itemDatabase.GetItem(id);
        characterItems.Add(toevoegen);
        inventoryUI.AddItem(toevoegen);
    }
    // voeg item toe aan de lijst als kopie
    public void GiveItem(Item item) {
        Item toevoegen = new Item(item);
        characterItems.Add(toevoegen);
        inventoryUI.AddItem(toevoegen);
    }

    public Item checkForItem(int id) {
        return characterItems.Find(item => item.id == id);
    }

    public void RemoveItem(int id) {
        Item item = checkForItem(id);
        if (item != null) {
            characterItems.Remove(item);
            inventoryUI.RemoveItem(item);
        }
    }

    private void Start() {
        foreach (int id in beginItems) {
            GiveItem(id);
        }

    }

    private void FixedUpdate() {
        if(DeathScreen.activeSelf && inventoryUI.gameObject.activeSelf) {
            inventoryUI.gameObject.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.E)&&!DeathScreen.activeSelf) {
            if (inventoryUI.gameObject.activeSelf) {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                LevelManager.Instance.Player.GetComponent<PlayerLook>().lockcamera(false);
            } else {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                LevelManager.Instance.Player.GetComponent<PlayerLook>().lockcamera(true);

            }
            inventoryUI.gameObject.SetActive(!inventoryUI.gameObject.activeSelf);
        }
    }
}
