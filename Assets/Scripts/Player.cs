using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    [SerializeField]
    Seeker seeker;
    [SerializeField]
    AILerp mover;
    [SerializeField]
    Animator animator;
    [SerializeField]
    SpriteRenderer rend;
    float dir = 1;
    Vector3 lastPos;

    private void Update()
    {
        dir = transform.position.x - lastPos.x;
        if (dir != 0)
            rend.flipX = dir < 0;
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            seeker.StartPath(transform.position, new Vector3(mousePos.x, mousePos.y, 0));
        }

        animator.SetBool("Moving", !mover.reachedEndOfPath && mover.hasPath);

        lastPos = transform.position;
    }
}
