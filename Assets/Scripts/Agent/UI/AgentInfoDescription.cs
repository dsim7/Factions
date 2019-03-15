using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AgentInfoDescription : MonoBehaviour
{
    public AgentObjectVariable selectedAgent;
    public Text text;

    void Start()
    {
        selectedAgent.RegisterAction(UpdateInfo);
    }

	void UpdateInfo()
    {
        text.text = selectedAgent.Value.description;
    }
}
