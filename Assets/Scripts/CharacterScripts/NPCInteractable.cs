using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteractable : Interactable
{
    [SerializeField]
    public Vector3 startPos;
    [SerializeField]
    public Conversation conversation;

    public void Start()
    {
        GameObject.Find("NPC").GetComponentInChildren<SpriteRenderer>().flipX = true;
        transform.position = startPos;
    }

    public override void OnInteract()
    {
        GameObject.Find("DialogueBox").GetComponent<DialogueManager>().conversation(conversation);
        print("conversation triggered");
    }
}
