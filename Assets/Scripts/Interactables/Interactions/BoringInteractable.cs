using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoringInteractable : SceneChangeInteractable
{
    public Conversation[] convos;

    public override void OnInteract()
    {
        if (GameManager.inst.inDialogue) return;

        if (PersistenceManager.inst.flags["hasBorer"] && !PersistenceManager.inst.flags["bored"])
        {
            base.OnInteract();
        }
        else
        {
            for (int i = 0; i < convos.Length; i++)
            {
                Conversation convo = convos[i];

                if (convo.Valid())
                {
                    GameObject.Find("DialogueManager").GetComponent<DialogueManager>().conversation(convo);
                }
            }
        }
    }
}
