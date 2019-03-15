using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class TraitAdder : AssetTemplate
{
    [SerializeField]
    AgentTrait traitAdded;
    bool traitUsed;

    public override void OnEquip(Agent agent)
    {
        if (!agent.traits.Contains(traitAdded))
        {
            traitUsed = true;
            agent.traits.Add(traitAdded);
        }
    }

    public override void OnUnequip(Agent agent)
    {
        if (traitUsed)
        {
            traitUsed = false;
            agent.traits.Remove(traitAdded);
        }
    }
}
