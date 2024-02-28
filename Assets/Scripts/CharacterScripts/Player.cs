using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using UnityEngine.EventSystems;
using System;

public class Player : MonoBehaviour
{
    public static Player inst;

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
    [SerializeField]
    bool wasMoving;
    Interactable queuedObj;

    Action onPathComplete;

    public bool IsMoving => !mover.reachedEndOfPath && mover.hasPath;

    private void Awake()
    {
        if (inst == null)
            inst = this;
        else if (inst != this)
            Destroy(this);
    }

    private void Update()
    {
        dir = transform.position.x - lastPos.x;
        if (dir != 0)
            rend.flipX = dir < 0;
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject() && !GameManager.inst.inDialogue)
        {
            onPathComplete = null;
            queuedObj = null;
            seeker.StartPath(transform.position, new Vector3(mousePos.x, mousePos.y, 0));
        }

        animator.SetBool("Moving", !mover.reachedEndOfPath && mover.hasPath);

        if (GameManager.inst.targettedObj != null)
        {
            Debug.Log("targetted object: " + GameManager.inst.targettedObj.Name);
            if (IsMoving || mover.pathPending)
            {
                if (queuedObj == null)
                {
                    Debug.Log("queueing interaction with: " + GameManager.inst.targettedObj.Name);
                    queuedObj = GameManager.inst.targettedObj;
                    onPathComplete = queuedObj.OnInteract;
                }
            }
            else
            {
                GameManager.inst.targettedObj.HandleInteractions();
            }
        }

        if (!IsMoving && wasMoving)
        {
            Debug.Log("interacting with: " + queuedObj.Name);
            onPathComplete();
            queuedObj = null;
            onPathComplete = null;
            wasMoving = false;
        }

        lastPos = transform.position;
        wasMoving = IsMoving;
    }


}
