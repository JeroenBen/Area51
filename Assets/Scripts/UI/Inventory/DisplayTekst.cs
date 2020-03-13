using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayTekst : MonoBehaviour
{
    private Text description;
    private GameObject ItemTextbox;

    // Start is called before the first frame update
    void Start()
    {
        ItemTextbox = GameObject.Find("ItemTextbox");
        description = GetComponentInChildren<Text>();
        ItemTextbox.SetActive(false);
    }

    public void MaakDescription(Item item) {
        string desc = "";
        if (item.stats.Count > 0) {
            foreach(var stat in item.stats) {
                desc += stat.Key.ToString() + ": " + stat.Value.ToString() + "\n";
            }
        }
        string formated = string.Format("<b>{0}</b>\n{1}\n\n<b>{2}</b>",item.title, item.description, desc);
        description.text = formated;
        ItemTextbox.SetActive(true);
    }
}
