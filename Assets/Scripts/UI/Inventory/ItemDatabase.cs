using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    public List<Item> items = new List<Item>();

    // on game start
    private void Awake() {
        main = this;
        BuildDatabase();
    }

    public static ItemDatabase main;
    // get item met id
    public Item GetItem(int id) {
        // return item met de geselecteerde id
        return items.Find(item => item.id == id);
    }
    // get item met naam
    public Item GetItem(string title) {
        // return item met de geselecteerde naam
        return items.Find(item => item.title == title);
    }

    // maak een database met alle items
    public void BuildDatabase() {
        items = new List<Item>{
            new Item(0, "Info", "gengsta test",
                new Dictionary<string, int>{
                    {"kogels" ,15},
                    {"swag" ,100}
                }
            ),
            new Item(1, "buttonbg", "dit is toch echt een ander item",
                new Dictionary<string, int>{
                    {"kogels" ,15},
                    {"swag" ,100}
                }
            ),
            new Item(2, "Trump Head", "A new piece of evidence!",new Dictionary<string, int>{ }),
            new Item(3, "Camera Roll", "So the moonlanding was fake!",new Dictionary<string, int>{ }),
            new Item(4, "AK-47", "Shoots really fast",new Dictionary<string, int>{ }),
            new Item(5, "Sample Weapon", "Bland, shitty weapon",new Dictionary<string, int>{ }),
            new Item(6, "Raygun", "Shoots lasars!",new Dictionary<string, int>{ }),
            new Item(7, "Revolver", "The original pewpew",new Dictionary<string, int>{ }),
            new Item(8, "Plunger", "Tool",new Dictionary<string, int>{ }),

    };
    }
}

