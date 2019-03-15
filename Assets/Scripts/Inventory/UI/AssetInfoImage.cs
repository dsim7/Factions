using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AssetInfoImage : MonoBehaviour
{
    public AssetVariable selectedAsset;
    public Image image;

    void Start()
    {
        selectedAsset.RegisterAction(UpdateInfo);
    }

    void UpdateInfo()
    {
        if (selectedAsset.Value != null && selectedAsset.Value.template != null)
        {
            image.sprite = selectedAsset.Value.template.image;
        }
    }
}
