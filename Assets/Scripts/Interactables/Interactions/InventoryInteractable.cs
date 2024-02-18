using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryInteractable : Interactable
{
    public InventoryItem item;
    private string description;
    public string flag;

    private void Awake()
    {
        if (PersistenceManager.inst != null && PersistenceManager.inst.flags.GetValueOrDefault(flag))
            gameObject.SetActive(false);
    }

    public override void OnInteract()
    {
        InventoryScript.inst.AddItem(item);
        PersistenceManager.inst.flags[flag] = true;
        Destroy(this.gameObject);
    }

    public override void OnLook()
    {
        description = item.description;
    }
}
