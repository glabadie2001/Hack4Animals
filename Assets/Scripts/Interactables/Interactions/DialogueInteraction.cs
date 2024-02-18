using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueInteraction : Interaction
{
    public Conversation[] convos;
    public override void OnActivate()
    {
        for (int i = 0; i < convos.Length; i++)
        {
            Conversation convo = convos[i];

            if (convo.Valid())
                GameObject.Find("DialogueManager").GetComponent<DialogueManager>().conversation(convo);
        }
    }
}
