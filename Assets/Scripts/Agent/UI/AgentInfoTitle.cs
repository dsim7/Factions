using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AgentInfoTitle : MonoBehaviour
{
    public AgentObjectVariable selectedAgent;
    public Text text;

    void Start()
    {
        selectedAgent.RegisterAction(UpdateInfo);
    }

    void UpdateInfo()
    {
        text.text = selectedAgent.Value.agentName;
    }
}
