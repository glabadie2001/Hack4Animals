﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu]
public class InventoryItem : ScriptableObject
{
    public string itemName;
    public Sprite image;
    [TextArea]
    public string description;
    public InventoryItem combinesWith;
    public InventoryItem combinesTo;
    public string comboFlag;
}