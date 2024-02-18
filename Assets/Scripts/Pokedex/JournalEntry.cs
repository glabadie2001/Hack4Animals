using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu]
public class JournalEntry : ScriptableObject
{
    public Sprite image;
    [TextArea]
    public string description;
}