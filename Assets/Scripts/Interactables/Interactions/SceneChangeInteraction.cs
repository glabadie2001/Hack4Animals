using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeInteractable : Interactable
{
    public string sceneName;

    public override void OnInteract()
    {
        PersistenceManager.inst.flags["sceneChanged"] = true;
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }
}
