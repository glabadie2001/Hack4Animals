using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Convo", menuName = "Conversation", order = -1)]
public class Conversation : ScriptableObject
{
    public ActivationCondition[] activationFlags;
    public string[] options;
    public string postFlag;
    public InventoryItem postItem;

    public bool Valid()
    {
        for (int i = 0; i < activationFlags.Length; i++)
        {
            ActivationCondition cond = activationFlags[i];
            if (PersistenceManager.inst.flags[cond.flag] != cond.state)
            {
                Debug.Log(cond.flag);
                return false;
            }
        }

        return true;
    }

    [System.Serializable]
    public class ActivationCondition
    {
        public string flag;
        public bool state;
    }
}

