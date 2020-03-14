using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DropBox : MonoBehaviour, IPointerClickHandler
{
    public UIItem selectedItem;
    public Inventory inventory;

    private void Start() {
        selectedItem = GameObject.Find("SelectedItem").GetComponent<UIItem>();
        inventory = LevelManager.Instance.Player.GetComponent<Inventory>();
    }


    // neemt alleen items als input, null
    public void drop(Item item) {
        Player player = LevelManager.Instance.Player;
        Instantiate(Resources.Load<GameObject>("PrefabsWorld/" + item.title), player.playerCamera.position, player.playerCamera.rotation);
        inventory.characterItems.Remove(item);
        Debug.Log("item dropped");
    }

    //delete het item uit inventory en ga verder
    public void OnPointerClick(PointerEventData eventData) {

        if (selectedItem.item != null) {
            drop(selectedItem.item);
            selectedItem.UpdateItem(null);
        }
    }
}
