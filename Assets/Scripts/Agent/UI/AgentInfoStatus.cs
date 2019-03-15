using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AgentInfoStatus : MonoBehaviour
{
    AgentStatus _agentStatus;
    public AgentStatus agentStatus { get { return _agentStatus; } set { _agentStatus = value; UpdateInfo(); } }
    
    public AgentObjectVariable selectedAgent;
    public Text text;

    void Start()
    {
        selectedAgent.RegisterAction(UpdateStatus);
    }

    void UpdateStatus()
    {
        if (agentStatus != null)
        {
            agentStatus.UnregisterAction(UpdateInfo);
        }
        agentStatus = selectedAgent.Value.status;
        if (agentStatus != null)
        {
            agentStatus.RegisterAction(UpdateInfo);
        }
    }

    void UpdateInfo()
    {
        text.text = selectedAgent.Value.status.Value.ToString();
    }
}
