using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueInteraction : Interaction
{
    public Conversation convo;
    public override void OnActivate()
    {
        GameObject.Find("DialogueManager").GetComponent<DialogueManager>().conversation(convo);
    }
}
