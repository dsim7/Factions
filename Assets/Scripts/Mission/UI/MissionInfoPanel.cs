using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionInfoPanel : MonoBehaviour
{
    CanvasGroup canvasGroup;
    
    public MissionInstanceVariable selectedMission;

    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();

        SetDisplayed(false);
        selectedMission.RegisterAction(UpdatePanel);
    }

    public void SetDisplayed(bool displayed)
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
        if (canvasGroup.alpha != 1f && selectedMission.Value != null)
        {
            SetDisplayed(true);
        }
        else if (canvasGroup.alpha != 0 && selectedMission.Value == null)
        {
            SetDisplayed(false);
        }
    }
}
