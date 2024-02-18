using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryInteractable : Interactable
{
    public InventoryItem item;
    private string description;

    public override void OnInteract()
    {
        GameManager.inst.player.GetComponent<InventoryScript>().AddItem(item);
        Destroy(this.gameObject);
    }

    public override void OnLook()
    {
        description = item.description;
    }
}
