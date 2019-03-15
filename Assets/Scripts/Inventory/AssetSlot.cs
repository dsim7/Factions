using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class AssetSlot : ObservedVariable<Asset>
{
    public bool locked;
}
