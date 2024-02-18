using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InventoryScript : MonoBehaviour
{
    public List<InventoryItem> inventoryItems = new();

    // Use this for initialization
    void Start()
    {
        UIManager.inst.DrawInventory(this);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public bool AddItem(InventoryItem item)
    {
        inventoryItems.Add(item);
        UIManager.inst.DrawInventory(this);
        return true;
    }

    public bool RemoveItem(InventoryItem item)
    {
        inventoryItems.Remove(item);
        UIManager.inst.DrawInventory(this);
        return true;
    }

    public bool CombineItems(InventoryItem item1, InventoryItem item2)
    {
        if (item1.combinesWith != item2.name)
            return false;
        
        inventoryItems.Remove(item1);
        inventoryItems.Remove(item2);
        inventoryItems.Add(item1.combinesTo);
        UIManager.inst.hoverText.text = item1.combinesTo.itemName + " obtained!";
        return true;
    }
}
