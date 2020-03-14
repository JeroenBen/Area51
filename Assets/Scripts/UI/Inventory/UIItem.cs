using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIItem : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Item item;
    private Image spriteImage;
    private UIItem selectedItem;
    private DisplayTekst displayTekst;
    private GameObject ItemTextbox;

    public void Awake() {
        ItemTextbox = GameObject.Find("ItemTextbox");
        spriteImage = GetComponent<Image>();
        UpdateItem(null);
        selectedItem = GameObject.Find("SelectedItem").GetComponent<UIItem>();
        displayTekst = GameObject.Find("Description").GetComponent<DisplayTekst>();
    }

    public void UpdateItem(Item item) {
        this.item = item;
        // kijk of het vakje leeg is
        if (this.item != null) {
            spriteImage.color = Color.white;
            spriteImage.sprite = this.item.icon;
        } else {
            spriteImage.color = Color.clear;
        }
    }


    //drag en drop
    public void OnPointerClick(PointerEventData eventData) {

        if (this.item != null) {
            if (selectedItem.item != null) {
                Item clone = new Item(selectedItem.item);
                selectedItem.UpdateItem(this.item);
                UpdateItem(clone);
            }
            else {
                selectedItem.UpdateItem(this.item);
                UpdateItem(null);
            }
        }
        else if (selectedItem.item != null) {
            UpdateItem(selectedItem.item);
            selectedItem.UpdateItem(null);
        }
    }

    //display allemaal info over item en stats
    public void OnPointerEnter(PointerEventData eventData) {
        if (this.item != null) {
            displayTekst.MaakDescription(this.item);
        }
    }
    public void OnPointerExit(PointerEventData eventData) {
        ItemTextbox.SetActive(false);
    }
}
