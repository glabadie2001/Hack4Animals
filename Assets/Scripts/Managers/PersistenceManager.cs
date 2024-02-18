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
        flags.Add("salmonRan", false);
        flags.Add("bored", false);
        flags.Add("phase1", true);
        flags.Add("phase2", false);
        flags.Add("phase3", false);
        flags.Add("hasBorer", false);
        flags.Add("hasPlate", false);
        flags.Add("canSalmonRun", false);
        flags.Add("troutSig", false);
        flags.Add("sequoiaSig", false);
        flags.Add("cedarSig", false);
        flags.Add("canPlate", false);
        flags.Add("hasBaitedPlate", false);
        flags.Add("baited", false);
    }
}
