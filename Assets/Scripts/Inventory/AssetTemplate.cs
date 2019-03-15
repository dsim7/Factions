
using UnityEngine;

public abstract class AssetTemplate : ScriptableObject
{
    public string assetName;
    public string description;
    public Sprite image;
    public int worth;

    public abstract void OnEquip(Agent agent);

    public abstract void OnUnequip(Agent agent);
}
