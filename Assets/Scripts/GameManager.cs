using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager inst;

    public Transform cursor;
    public Interactable targettedObj;

    private void Awake()
    {
        if (inst == null)
            inst = this;
        else if (inst != this)
            Destroy(this);
    }

    private void Start()
    {
        Cursor.visible = false;
    }

    private void Update()
    {
        UpdateCursor();

        targettedObj = GetHoveredObj();
    }

    Interactable GetHoveredObj()
    {
        RaycastHit2D[] hit = new RaycastHit2D[1];
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics2D.Raycast(ray.origin, ray.direction, new ContactFilter2D(), hit);

        if (hit[0].transform == null) return null;

        return hit[0].transform.GetComponent<Interactable>();
    }

    void UpdateCursor()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        cursor.transform.position = new Vector3(mousePos.x, mousePos.y, 0);
    }
}
