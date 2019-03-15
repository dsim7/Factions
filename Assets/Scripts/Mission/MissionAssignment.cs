
using System;

[Serializable]
public class MissionAssignment
{
    public AgentVariable assignedAgent = new AgentVariable();
    public BoolVariable locked = new BoolVariable();
}
