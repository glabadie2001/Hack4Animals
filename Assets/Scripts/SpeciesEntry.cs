using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SpeciesEntry : ScriptableObject
{
    public string sciName;
    public string commonName;
    public string height;
    public string weight;
    public string desc;
    public Sprite icon;

}

[CreateAssetMenu]
public class speciesRegistry : ScriptableObject
{
    public SpeciesEntry[] entries;
    public int count;

    public speciesRegistry(int _count)
    {
        count = _count;
        entries = new SpeciesEntry[count];
    }
}