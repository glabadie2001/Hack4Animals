using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistenceManager : MonoBehaviour
{
    public static PersistenceManager inst;

    public Dictionary<string, bool> flags = new();

    private void Awake()
    {
        if (inst == null)
            inst = this;
        else if (inst != this)
            Destroy(this);

        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        flags.Add("takenNet", false);
        flags.Add("hasFishingNet", false);
    }
}
