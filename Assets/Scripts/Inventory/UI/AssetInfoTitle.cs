using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AssetInfoTitle : MonoBehaviour
{
    public AssetVariable selectedAsset;
    public Text text;

    void Start()
    {
        selectedAsset.RegisterAction(UpdateInfo);
    }

    void UpdateInfo()
    {
        if (selectedAsset.Value != null && selectedAsset.Value.template != null)
        {
            text.text = selectedAsset.Value.template.assetName;
        }
    }
}
