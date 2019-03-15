using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class AgentInfoStats : MonoBehaviour
{
    public AgentObjectVariable selectedAgent;

    public Text stealth, combat, intellect, charisma, traits;

    void Start()
    {
        selectedAgent.RegisterPreAction(UnobserveAgentStats);
        selectedAgent.RegisterAction(ObserveAgentStats);
        selectedAgent.RegisterAction(UpdateStats);
        selectedAgent.RegisterPreAction(UnobserveAgentTraits);
        selectedAgent.RegisterAction(ObserveAgentTraits);
        selectedAgent.RegisterAction(UpdateTraits);

        UpdateStats();
        UpdateTraits();
    }

    void UnobserveAgentStats()
    {
        if (selectedAgent.Value != null)
        {
            selectedAgent.Value.onStatChange.RemoveListener(UpdateStats);
        }
    }

    void ObserveAgentStats()
    {
        selectedAgent.Value.onStatChange.AddListener(UpdateStats);
    }

    void UpdateStats()
    {
        if (selectedAgent.Value != null)
        {
            stealth.text = selectedAgent.Value.stealth.ToString();
            combat.text = selectedAgent.Value.combat.ToString();
            intellect.text = selectedAgent.Value.intelligence.ToString();
            charisma.text = selectedAgent.Value.charisma.ToString();
        }
    }

    void UnobserveAgentTraits()
    {
        if (selectedAgent.Value != null)
        {
            selectedAgent.Value.traits.UnregisterAction(UpdateTraits);
        }
    }

    void ObserveAgentTraits()
    {
        selectedAgent.Value.traits.RegisterAction(UpdateTraits);
    }

    void UpdateTraits()
    {
        if (selectedAgent.Value != null)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < selectedAgent.Value.traits.Count; i++)
            {
                sb.Append(selectedAgent.Value.traits[i].ToString());
                if (i != selectedAgent.Value.traits.Count - 1)
                {
                    sb.Append(", ");
                }
            }
            traits.text = sb.ToString();
        }
    }
}
