using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Inventory : ObservedList<AssetSlot>
{
    public AssetSlot GetNextOpenSlot()
    {
        for (int i = 0; i < Count; i++)
        {
            if (this[i].Value.template == null)
            {
                return this[i];
            }
        }
        return null;
    }
}
