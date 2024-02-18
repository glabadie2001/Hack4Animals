using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoringController : MonoBehaviour
{
    public GameObject[] boringStages;
    public int stageIndex = 0;
    public LayerMask mask;

    private void Awake()
    {
        Cursor.visible = true;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (stageIndex == 4)
            {
                PersistenceManager.inst.flags["bored"] = true;
                PersistenceManager.inst.flags["sceneChanged"] = true;
                SceneManager.LoadScene("Sandbox", LoadSceneMode.Single);
            }

            RaycastHit2D[] hit = new RaycastHit2D[1];
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            ContactFilter2D filter = new ContactFilter2D();
            filter.SetLayerMask(mask);

            Physics2D.Raycast(ray.origin, ray.direction, filter, hit);
            Debug.Log(hit[0].transform);
            if (hit[0].transform == null) return;

            stageIndex++;

            boringStages[stageIndex].SetActive(true);
            boringStages[stageIndex - 1].SetActive(false);
        }
    }
}
