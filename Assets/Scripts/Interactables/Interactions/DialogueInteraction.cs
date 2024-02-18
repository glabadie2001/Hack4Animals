using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueInteraction : Interaction
{
    int convoID = 0;
    public override void OnActivate()
    {
        GameObject.Find("DialogueManager").GetComponent<DialogueManager>().conversation(convoID);
    }
}
