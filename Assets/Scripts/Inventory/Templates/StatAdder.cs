using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class StatAdder : AssetTemplate
{
    [Space]
    public int stealthBonus;
    public int combatBonus;
    public int intellectBonus;
    public int charismaBonus;

    [Space]
    public float stealthBonusCoef;
    public float combatBonusCoef;
    public float intellectBonusCoef;
    public float charismaBonusCoef;

    public override void OnEquip(Agent agent)
    {
        agent.constModStealth += stealthBonus;
        agent.constModCombat += combatBonus;
        agent.constModIntelligence += intellectBonus;
        agent.constModCharisma += charismaBonus;

        agent.modStealth += stealthBonusCoef;
        agent.modCombat += combatBonusCoef;
        agent.modIntelligence += intellectBonusCoef;
        agent.modCharisma += charismaBonusCoef;
    }

    public override void OnUnequip(Agent agent)
    {
        agent.constModStealth -= stealthBonus;
        agent.constModCombat -= combatBonus;
        agent.constModIntelligence -= intellectBonus;
        agent.constModCharisma -= charismaBonus;

        agent.modStealth -= stealthBonusCoef;
        agent.modCombat -= combatBonusCoef;
        agent.modIntelligence -= intellectBonusCoef;
        agent.modCharisma -= charismaBonusCoef;
    }
}
