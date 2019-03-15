
using UnityEngine;

public class AgentInfoPanel : MonoBehaviour
{
    CanvasGroup canvasGroup;

    public AgentObjectVariable selectedAgent;

    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();

        SetDisplayed(false);
        selectedAgent.RegisterAction(UpdatePanel);
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
        if (canvasGroup.alpha != 1f && selectedAgent.Value != null)
        {
            SetDisplayed(true);
        }
        else if (canvasGroup.alpha != 0 && selectedAgent.Value == null)
        {
            SetDisplayed(false);
        }
    }
}
