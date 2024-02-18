using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalmonInteractable : SceneChangeInteractable
{
    public override void OnInteract()
    {
        if (PersistenceManager.inst.flags["hasFishingNet"])
        {
            base.OnInteract();
        }
        else
        {
            Debug.Log("I need something to fish with!");
        }
    }
}
