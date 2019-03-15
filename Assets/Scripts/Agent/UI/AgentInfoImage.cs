using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AgentInfoImage : MonoBehaviour
{
    public AgentObjectVariable selectedAgent;
    public Image image;

    void Start()
    {
        selectedAgent.RegisterAction(UpdateInfo);
    }

	void UpdateInfo()
    {
        image.sprite = selectedAgent.Value.image;
    }
}
