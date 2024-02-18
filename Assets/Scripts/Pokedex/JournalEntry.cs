using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu]
public class JournalEntry : ScriptableObject
{
    public string activationFlag;
    public Sprite image;
    [TextArea]
    public string description;

    public bool Active()
    {
        return PersistenceManager.inst.flags[activationFlag];
    }
}