using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Player : MonoBehaviour
{
    [SerializeField]
    Seeker seeker;

    private void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            seeker.StartPath(transform.position, new Vector3(mousePos.x, mousePos.y, 0));
        }
    }
}
