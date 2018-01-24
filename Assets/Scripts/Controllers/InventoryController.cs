using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour {
    public static InventoryController Instance;

    public List<ItemStack> inventory;

    public Transform scrollList;
    public GameObject itemPrefab;

    void Start() {
        if(Instance != null) {
            Debug.Log("InventoryController - Can only have 1 Instance!");
            return;
        }

        Instance = this;

        inventory = new List<ItemStack>();
    }

    public void AddItemToInvetory(ItemStack stack) {
        bool hasItem = false;

        foreach(ItemStack i in inventory) {
            if(i.item.name == stack.item.name) {
                hasItem = true;
                i.amount += stack.amount;

                GameObject go = scrollList.Find(i.item.name).gameObject;

                Text[] prefabText = go.GetComponentsInChildren<Text>();
                prefabText[0].text = i.amount.ToString();

                return;
            }
        }

        if(!hasItem) {
            inventory.Add(stack);

            GameObject go = Instantiate(itemPrefab, scrollList);
            go.name = stack.item.name;

            Text[] prefabText = go.GetComponentsInChildren<Text>();
            prefabText[0].text = stack.amount.ToString();
            prefabText[1].text = stack.item.name;
        }
    }

    private void ClearInventory() {
        for(int i = 0; i < scrollList.childCount; i++) {
            GameObject.Destroy(scrollList.GetChild(i).gameObject);
        }
    }

    public void LoadInventory(List<ItemStack> loadedList) {
        ClearInventory();
        inventory.Clear();

        foreach(ItemStack stack in loadedList) {
            AddItemToInvetory(stack);
        }
    }
}
