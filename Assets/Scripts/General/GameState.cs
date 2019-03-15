

using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class GameState : ScriptableObject
{
    public int money;
    public AgentList agents;
    public MissionList missions;
    public Inventory inventory;

    [Space]
    public bool tutorial;
    
}
