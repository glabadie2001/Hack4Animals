using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Button))]
public class InventoryButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public InventoryItem item;
    Button button;

    public void OnPointerEnter(PointerEventData eventData)
    {
        GameManager.inst.hoverItem = item;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        GameManager.inst.hoverItem = null;
    }

    private void Start()
    {
        button = GetComponent<Button>();

        button.onClick.RemoveAllListeners();

        button.onClick.AddListener(() =>
        {
            if (GameManager.inst.heldItem == null)
            {
                GameManager.inst.heldItem = item;
            }
            else
            {
                InventoryScript.inst.CombineItems(GameManager.inst.heldItem, this.item);
            }
        });
    }
}
