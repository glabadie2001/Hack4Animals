using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Convo", menuName = "H4H", order = -1)]
public class Conversation : ScriptableObject
{
    public int length;
    public string[] options;
}

