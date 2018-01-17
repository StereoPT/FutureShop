using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemController : MonoBehaviour {
    public static ItemController Instance;

    public Item[] availableItems;

    public Text itemDisplayText;

    void Start() {
        if (Instance != null) {
            Debug.Log("ItemController - Can only have 1 Instance!");
            return;
        }

        Instance = this;
    }

    public void GetItem() {
        Item item = availableItems[Random.Range(0, availableItems.Length)];

        InventoryController.Instance.AddItemToInvetory(new ItemStack(item, 1));

        itemDisplayText.text = item.name;
    }
}
