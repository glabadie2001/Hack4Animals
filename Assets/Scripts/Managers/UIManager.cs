using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager inst;

    public TextMeshProUGUI hoverText;

    public RectTransform cursor;

    [SerializeField]
    Animator invAnimator;
    [SerializeField]
    TextMeshProUGUI openText;
    [SerializeField]
    TextMeshProUGUI closeText;
    bool showInv;

    private void Awake()
    {
        if (inst == null)
            inst = this;
        else if (inst != this)
            Destroy(this);
    }

    public void UpdateHoverUI(Interactable hoverObj)
    {
        if (hoverObj == null)
            hoverText.text = "";
        else
            hoverText.text = hoverObj.Name;
    }

    public void ToggleInventory()
    {
        showInv = !showInv;
        invAnimator.SetBool("Opened", showInv);
        openText.gameObject.SetActive(!showInv);
        closeText.gameObject.SetActive(showInv);
    }

    public void UpdateCursor()
    {
        Cursor.visible = false;
        RawImage renderer = cursor.GetComponent<RawImage>();

        Vector3 mousePos = Input.mousePosition;
        cursor.transform.position = new Vector3(mousePos.x, mousePos.y, 0);

        if (GameManager.inst.targettedObj != null)
            renderer.color = Color.red;
        else
            renderer.color = Color.white;

        UpdateHoverUI(GameManager.inst.targettedObj);
    }
}
