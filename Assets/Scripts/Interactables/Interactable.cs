using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField]
    string objName;

    public string Name
    {
        get { return objName; }
    }

    public virtual void OnHover()
    {

    }

    public virtual void OnInteract()
    {

    }

    public virtual void OnLook()
    {

    }

    public void HandleInteractions()
    {
        OnHover();

        if (Input.GetMouseButtonDown(0))
        {
            OnInteract();
        }

        if (Input.GetMouseButtonDown(1))
        {
            OnLook();
        }
    }
}
