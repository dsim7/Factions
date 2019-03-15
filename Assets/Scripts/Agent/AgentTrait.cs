using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class AgentTrait : ScriptableObject
{
    public override string ToString()
    {
        return name;
    }
}
