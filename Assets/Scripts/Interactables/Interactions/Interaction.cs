using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public abstract class Interaction : ScriptableObject
{
    public string displayText;
    public InputType activation;
    public InteractionEvent onActivate;
}

[System.Serializable]
public class InteractionEvent : UnityEvent<Interactable>
{

}

public enum InputType
{
    LeftClick,
    RightClick
}
