using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speciesEntry
{
    public string sciName;
    public string commonName;
    public string height;
    public string weight;
    public string desc;

    public speciesEntry()
    {
        sciName = "Sequoia sempervirens";
        commonName = "Coastal Redwood";
        height = "200-330 ft";
        weight = "424 tons";
        desc = "Flavor text";
    }

    public speciesEntry(string _sciName, string _commonName, string _height, string _weight, string _desc)
    {
        sciName = _sciName;
        commonName = _commonName;
        height = _height;
        weight = _weight;
        desc = _desc;
    }
}

public class speciesRegistry
{
    public speciesEntry[] entries;
    public int count;

    public speciesRegistry(int _count)
    {
        count = _count;
        entries = new speciesEntry[count];
        for (int i = 0; i < count; i++)
        {
            entries[i] = new speciesEntry();
        }
    }
}