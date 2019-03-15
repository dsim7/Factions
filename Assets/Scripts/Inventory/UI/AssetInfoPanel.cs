using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetInfoPanel : MonoBehaviour
{
    CanvasGroup canvasGroup;

    public AssetVariable selectedAsset;

    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();

        SetDisplayed(false);
        selectedAsset.RegisterAction(UpdatePanel);
    }

    void SetDisplayed(bool displayed)
    {
        if (displayed)
        {
            canvasGroup.alpha = 1f;
            canvasGroup.blocksRaycasts = true;
        }
        else
        {
            canvasGroup.alpha = 0;
            canvasGroup.blocksRaycasts = false;
        }
    }

    public void UpdatePanel()
    {
        if (canvasGroup.alpha != 1f && selectedAsset.Value != null)
        {
            SetDisplayed(true);
        }
        else if (canvasGroup.alpha != 0 && selectedAsset.Value == null)
        {
            SetDisplayed(false);
        }
    }
}
