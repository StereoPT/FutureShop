using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CraftedItem : Item {

    public List<ItemStack> requiredItems;

    public CraftedItem(string name, List<ItemStack> requiredItems) : base(name) {
        this.requiredItems = requiredItems;
    }
}
