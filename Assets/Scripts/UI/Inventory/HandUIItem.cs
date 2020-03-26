using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HandUIItem : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Item item;
    private Image spriteImage;
    public UIItem selectedItem;
    public DisplayTekst displayTekst;
    public GameObject ItemTextbox;
    public GameObject iconHand;

    public void Awake() { 
        spriteImage = GetComponent<Image>();
        UpdateItem(null);

    }

    public void UpdateItem(Item item) {
        this.item = item;
        // kijk of het vakje leeg is
        if (this.item != null) {
            spriteImage.color = Color.white;
            spriteImage.sprite = this.item.icon;
            iconHand.SetActive(false);
        } else {
            spriteImage.color = Color.clear;
            iconHand.SetActive(true);
        }
    }

    public void UpdateHand(Item item) {
        Player player = LevelManager.Instance.Player;
        if (item != null) {
           
            if(player.curItem != null) {
                Destroy(player.curItem);
            }
            player.curItem = Instantiate(Resources.Load<GameObject>("PrefabsHand/" + item.title), player.playerCamera);

            Debug.Log(item.title.ToString());
        } else {
            if (player.curItem != null) {
                Destroy(player.curItem);
            }
        }
    }

    //drag en drop
    public void OnPointerClick(PointerEventData eventData) {

        if (this.item != null) {
            if (selectedItem.item != null) {
                Item clone = new Item(selectedItem.item);
                UpdateHand(clone);
                selectedItem.UpdateItem(this.item);
                UpdateItem(clone);
            } else {
                UpdateHand(null);
                selectedItem.UpdateItem(this.item);
                UpdateItem(null);
            }
        } else if (selectedItem.item != null) {
            UpdateItem(selectedItem.item);
            selectedItem.UpdateItem(null);
            UpdateHand(this.item);
        }
    }

    //display allemaal info over item en stats
    public void OnPointerEnter(PointerEventData eventData) {
        if (item != null) {
            displayTekst.MaakDescription(item);
        }
    }
    public void OnPointerExit(PointerEventData eventData) {
        ItemTextbox.SetActive(false);
    }
}
