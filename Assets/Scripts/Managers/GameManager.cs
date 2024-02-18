using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager inst;

    public Interactable targettedObj;

    public Player player;

    public InventoryItem heldItem;

    private void Awake()
    {
        if (inst == null)
            inst = this;
        else if (inst != this)
            Destroy(this);
    }

    private void Update()
    {
        targettedObj = GetHoveredObj();

        if (targettedObj != null)
        {
            targettedObj.HandleInteractions();
        }

        UIManager.inst.UpdateCursor();
    }

    Interactable GetHoveredObj()
    {
        RaycastHit2D[] hit = new RaycastHit2D[1];
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics2D.Raycast(ray.origin, ray.direction, new ContactFilter2D(), hit);

        if (hit[0].transform == null) return null;

        return hit[0].transform.GetComponent<Interactable>();
    }
}
