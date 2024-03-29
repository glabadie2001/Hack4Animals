using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour
{
    public static UIManager inst;

    public TextMeshProUGUI hoverText;

    public RectTransform cursor;
    public Sprite defaultCursor;

    [Header("Inventory")]
    [SerializeField]
    Animator invAnimator;
    [SerializeField]
    TextMeshProUGUI invOpenText;
    [SerializeField]
    TextMeshProUGUI invCloseText;
    public bool showInv;
    [SerializeField]
    Image[] invSlots;

    [Header("Pokedex")]
    [SerializeField]
    Animator dexAnimator;
    [SerializeField]
    TextMeshProUGUI dexOpenText;
    [SerializeField]
    TextMeshProUGUI dexCloseText;
    [SerializeField]
    Image dexImage;
    [SerializeField]
    TextMeshProUGUI dexBodyText;
    public JournalEntry[] dexEntries;
    public int dexEntry = 0;
    public bool showDex;

    private void Awake()
    {
        if (inst == null)
            inst = this;
        else if (inst != this)
            Destroy(this);

        //DontDestroyOnLoad(this);
    }

    public void IncrementDex()
    {
        dexEntry = (dexEntry + 1) % dexEntries.Length;
        DrawDex();
    }

    public void DecrementDex()
    {
        dexEntry = (dexEntry - 1);
        if (dexEntry < 0)
            dexEntry = dexEntries.Length - 1;
        DrawDex();
    }

    public void UpdateHoverUI()
    {
        if (GameManager.inst.targettedObj != null && !EventSystem.current.IsPointerOverGameObject())
        {
            if (GameManager.inst.heldItem != null)
                hoverText.text = string.Format("Use {0} on {1}", GameManager.inst.heldItem.itemName, GameManager.inst.targettedObj.Name);
            else
                hoverText.text = GameManager.inst.targettedObj.Name;
        }
        else if (GameManager.inst.hoverItem != null)
        {
            if (GameManager.inst.heldItem != null && GameManager.inst.heldItem != GameManager.inst.hoverItem)
                hoverText.text = string.Format("Combine {0} with {1}", GameManager.inst.hoverItem.itemName, GameManager.inst.heldItem.itemName);
            else
                hoverText.text = GameManager.inst.hoverItem.itemName;
        }
        else
            hoverText.text = "";
    }

    public void ToggleInventory()
    {
        if (PersistenceManager.inst.flags["sceneChanged"])
        {
            DrawInventory();
            PersistenceManager.inst.flags["sceneChanged"] = false;
        }

        if (showDex)
            ToggleDex();

        showInv = !showInv;
        invAnimator.SetBool("Opened", showInv);
        invOpenText.gameObject.SetActive(!showInv);
        invCloseText.gameObject.SetActive(showInv);
    }

    public void ToggleDex()
    {
        if (showInv)
            ToggleInventory();

        showDex = !showDex;
        dexAnimator.SetBool("Opened", showDex);
        dexOpenText.gameObject.SetActive(!showDex);
        dexCloseText.gameObject.SetActive(showDex);

        DrawDex();
    }

    public void DrawDex()
    {
        JournalEntry entry = dexEntries[dexEntry];

        dexImage.sprite = entry.image;

        if (entry.Active())
            dexBodyText.text = entry.description;
        else
            dexBodyText.text = "";
    }

    public void UpdateCursor()
    {
        Cursor.visible = false;
        Image renderer = cursor.GetComponent<Image>();

        Vector3 mousePos = Input.mousePosition;
        cursor.transform.position = new Vector3(mousePos.x, mousePos.y, 0);

        if (GameManager.inst.heldItem == null)
        {
            renderer.sprite = defaultCursor;

            if (GameManager.inst.targettedObj != null && !EventSystem.current.IsPointerOverGameObject())
                renderer.color = Color.red;
            else
                renderer.color = Color.white;
        }
        else
        {
            renderer.sprite = GameManager.inst.heldItem.image;
            renderer.color = Color.white;
        }

        UpdateHoverUI();
    }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    public void DrawInventory()
    {
        int invSize = InventoryScript.inst.inventoryItems.Count;
        
        for (int i = 0; i < 8; i++)
        {
            if (i < invSize)
            {
                invSlots[i].GetComponent<InventoryButton>().item = InventoryScript.inst.inventoryItems[i];
                invSlots[i].sprite = InventoryScript.inst.inventoryItems[i].image;
                invSlots[i].preserveAspect = true;
            }
            else
            {
                invSlots[i].GetComponent<InventoryButton>().item = null;
                invSlots[i].sprite = null;
            }
        }
    }
}
