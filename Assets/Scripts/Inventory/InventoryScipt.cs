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
}
