using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InventoryScript : MonoBehaviour
{
    public static InventoryScript inst;

    public List<InventoryItem> inventoryItems = new();

    private void Awake()
    {
        if (inst == null)
            inst = this;
        else if (inst != this)
            Destroy(this);

        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public bool AddItem(InventoryItem item)
    {
        inventoryItems.Add(item);
        UIManager.inst.DrawInventory();
        return true;
    }

    public bool RemoveItem(InventoryItem item)
    {
        inventoryItems.Remove(item);
        UIManager.inst.DrawInventory();
        return true;
    }

    public bool CombineItems(InventoryItem item1, InventoryItem item2)
    {
        if (item1.combinesWith == null || item1.combinesWith != item2)
        {
            GameManager.inst.heldItem = null;
            return false;
        }

        RemoveItem(item1);
        RemoveItem(item2);
        AddItem(item1.combinesTo);
        //UIManager.inst.hoverText.text = item1.combinesTo.itemName + " obtained!";
        GameManager.inst.hoverItem = null;
        GameManager.inst.heldItem = null;

        if (item1.combinesTo.comboFlag != "")
        {
            PersistenceManager.inst.flags[item1.combinesTo.comboFlag] = true;
        }

        return true;
    }
}
