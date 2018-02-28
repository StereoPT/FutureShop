using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemController : MonoBehaviour {
    public static ItemController Instance;

    public Text itemDisplayText;

    private List<Item> items;
    private List<CraftedItem> craftedItems;

    void Start() {
        if (Instance != null) {
            Debug.Log("ItemController - Can only have 1 Instance!");
            return;
        }

        Instance = this;

        items = new List<Item>();
        craftedItems = new List<CraftedItem>();

        //Normal Items
        CreateItem(new Item("Wires"));
        CreateItem(new Item("Electronics"));
        CreateItem(new Item("Aluminium"));
        CreateItem(new Item("Sensors"));
        CreateItem(new Item("Copper"));

        //Crafted Items
        CreateCraftedItem(new CraftedItem("Circuit", new List<ItemStack> {
            new ItemStack(items[0], 2), new ItemStack(items[1], 3)
        }));
    }

    void CreateItem(Item i) {
        items.Add(i);
    }

    void CreateCraftedItem(CraftedItem ci) {
        craftedItems.Add(ci);
    }

    public void GetItem() {
        Item item = items[Random.Range(0, items.Count)];
        InventoryController.Instance.AddItemToInvetory(new ItemStack(item, 1));
        itemDisplayText.text = item.name;
    }
}
