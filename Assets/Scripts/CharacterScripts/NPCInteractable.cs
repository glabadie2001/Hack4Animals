using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteractable : Interactable
{
    [SerializeField]
    public Vector3 startPos;
    [SerializeField]
    public Conversation[] conversations;

    public void Start()
    {
        //GameObject.Find("NPC").GetComponentInChildren<SpriteRenderer>().flipX = true;
        //transform.position = startPos;
    }

    public override void OnInteract()
    {
        if (GameManager.inst.inDialogue) return;

        for (int i = 0; i < conversations.Length; i++)
        {
            Conversation convo = conversations[i];

            if (convo.Valid())
            {
                GameObject.Find("DialogueManager").GetComponent<DialogueManager>().conversation(convo);
                print(string.Format("conversation {0} triggered", convo.name));
            }
        }

    }
}
