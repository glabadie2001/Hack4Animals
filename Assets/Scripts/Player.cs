using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    [SerializeField]
    Seeker seeker;

    private void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            seeker.StartPath(transform.position, new Vector3(mousePos.x, mousePos.y, 0));
        }
    }
}
