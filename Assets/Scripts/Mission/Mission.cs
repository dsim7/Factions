
using System;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu]
public class Mission : ScriptableObject
{
    public const int MAX_AGENTS = 3;

    [Space]
    public GameState saveGame;

    [Space]
    public string title;
    public string description;

    [Space]
    public Conversation introConversation;
    public Conversation successConversation;
    public Conversation failConversation;

    [Space]
    public int stealthReq;
    public int combatReq;
    public int intellectReq;
    public int charismaReq;
    [Space]
    public AssetTemplate[] rewards;

    [Space]
    public int durationInSeconds;
    public long duration { get { return new TimeSpan(0, 0, durationInSeconds).Ticks; } }

    [Space]
    public MissionStatus status;
    public MissionAssignment[] assignments = new MissionAssignment[MAX_AGENTS];

    [Space]
    public long startTime;
    public long completeTime;

    [Space]
    public bool isSuccess;

    public void DiscoverMission()
    {
        Reset();
        saveGame.missions.Add(this);
    }

    public void StartMission()
    {
        startTime = DateTime.Now.Ticks;
        completeTime = startTime + duration;
        status.Value = MissionStatusEnum.Active;
        for (int i = 0; i < 3; i++)
        {
            assignments[i].locked.Value = true;
            if (assignments[i].assignedAgent.Value != null)
            {
                assignments[i].assignedAgent.Value.status.Value = AgentStatusEnum.Active;
            }
        }
    }

    public void CompleteMission()
    {
        status.Value = MissionStatusEnum.Complete;
    }

    public void EndMission()
    {
        int totalStealth = 0, totalCombat = 0, totalIntellect = 0, totalCharisma = 0;
        for (int i = 0; i < assignments.Length; i++)
        {
            if (assignments[i].assignedAgent.Value != null)
            {
                totalStealth += assignments[i].assignedAgent.Value.stealth;
                totalCombat += assignments[i].assignedAgent.Value.combat;
                totalIntellect += assignments[i].assignedAgent.Value.intelligence;
                totalCharisma += assignments[i].assignedAgent.Value.charisma;
            }
        }
        if (totalStealth >= stealthReq && totalCombat >= combatReq &&
            totalIntellect >= intellectReq && totalCharisma >= charismaReq)
        {
            isSuccess = true;
        }

        for (int i = 0; i < 3; i++)
        {
            if (assignments[i].assignedAgent.Value != null)
            {
                assignments[i].assignedAgent.Value.status.Value = AgentStatusEnum.Idle;
            }
        }
        status.Value = MissionStatusEnum.Ended;
    }

    public void ClaimReward()
    {
        if (saveGame.inventory.GetNextOpenSlot() != null)
        {
            Asset newAsset = new Asset();
            newAsset.template = rewards[UnityEngine.Random.Range(0, rewards.Length)];
            saveGame.inventory.GetNextOpenSlot().Value = newAsset;
        }
    }

    public void Reset()
    {
        isSuccess = false;
        status.Value = MissionStatusEnum.Pending;
        startTime = 0;
        completeTime = 0;
        assignments = new MissionAssignment[MAX_AGENTS];
        for (int i = 0; i < assignments.Length; i++)
        {
            assignments[i] = new MissionAssignment();
        }
    }
}




