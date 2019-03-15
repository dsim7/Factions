using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu]
public class AgentSet : RuntimeSet<Agent>
{
    [SerializeField]
    AgentEvent agentAdded;
    [SerializeField]
    AgentEvent agentRemoved;
}

public class AgentEvent : UnityEvent<Agent> { }
