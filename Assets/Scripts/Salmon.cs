using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salmon : MonoBehaviour
{

    private void OnMouseDown()
    {
        Debug.Log("Hello World");
        //SalmonController increment SalmonCount
        SalmonController.inst.SalmonCount++;
        Debug.Log(SalmonController.inst.SalmonCount);
        Destroy(gameObject);
    }
}
