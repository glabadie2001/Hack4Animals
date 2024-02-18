using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SalmonController : MonoBehaviour
{
    public static SalmonController inst;
    public int SalmonCount;
    public TextMeshProUGUI CountText;

    private void Awake()
    {
        if (inst == null)
            inst = this;
        else if (inst != this)
            Destroy(this);

        Cursor.visible = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        SalmonCount = 0;
        CountText.text = "CAUGHT: " + SalmonCount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        CountText.text = "CAUGHT: " + SalmonCount.ToString();
        if (SalmonCount > 9)
        {
            PersistenceManager.inst.flags["salmonRan"] = true;
            SceneManager.LoadScene("Sandbox", LoadSceneMode.Single);
        }
    }

    //public void UpdateCursor()
    //{
    //    Cursor.visible = false;
    //    Image renderer = cursor.GetComponent<Image>();

    //    Vector3 mousePos = Input.mousePosition;
    //    cursor.transform.position = new Vector3(mousePos.x, mousePos.y, 0);

    //    if (GameManager.inst.heldItem == null)
    //    {
    //        renderer.sprite = defaultCursor;

    //        if (GameManager.inst.targettedObj != null && !EventSystem.current.IsPointerOverGameObject())
    //            renderer.color = Color.red;
    //        else
    //            renderer.color = Color.white;
    //    }
    //    else
    //    {
    //        renderer.sprite = GameManager.inst.heldItem.image;
    //        renderer.color = Color.white;
    //    }

    //    UpdateHoverUI();
    //}
}
