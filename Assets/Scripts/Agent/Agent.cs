
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu]
public class Agent : ScriptableObject
{
    [Space]
    public string agentName;
    public string description;
    public Sprite image;
    
    [Space]
    public AgentStatus status;

    [Space]
    [SerializeField]
    int baseStealth;
    [SerializeField]
    int baseCombat;
    [SerializeField]
    int baseCharisma;
    [SerializeField]
    int baseIntelligence;

    [NonSerialized]
    public float modStealth = 1, modCombat = 1, modCharisma = 1, modIntelligence = 1;
    [NonSerialized]
    public int constModStealth = 0, constModCombat = 0, constModCharisma = 0, constModIntelligence = 0;

    public int stealth { get { return (int) (baseStealth * modStealth + constModStealth); } }
    public int combat { get { return (int) (baseCombat * modCombat + constModCombat); } }
    public int charisma { get { return (int) (baseCharisma * modCharisma + constModCharisma); } }
    public int intelligence { get { return (int) (baseIntelligence * modIntelligence + constModIntelligence); } }

    [Header("Traits")]
    public TraitsList traits;

    [Header("Inventory")]
    public Inventory inventory;

    [NonSerialized]
    public UnityEvent onStatChange = new UnityEvent();

    public void OnEnable()
    {
        for (int i = 0; i < inventory.Count; i++)
        {
            inventory[i].RegisterAction(EquipItems);
            inventory[i].RegisterPreAction(UnequipItems);
        }
        EquipItems();

        status.RegisterAction(LockInventory);
        LockInventory();
    }

    public void OnDisable()
    {
        Debug.Log("Agent disable");
        for (int i = 0; i < inventory.Count; i++)
        {
            inventory[i].UnregisterAction(EquipItems);
            inventory[i].UnregisterPreAction(UnequipItems);
        }
        UnequipItems();

        status.RegisterAction(LockInventory);
        LockInventory();
    }

    void EquipItems()
    {
        for (int i = 0; i < inventory.Count; i++)
        {
            if (inventory[i].Value != null && inventory[i].Value.template != null)
            {
                inventory[i].Value.template.OnEquip(this);
            }
        }
        onStatChange.Invoke();
    }

    void UnequipItems()
    {
        for (int i = 0; i < inventory.Count; i++)
        {
            if (inventory[i].Value != null && inventory[i].Value.template != null)
            {
                inventory[i].Value.template.OnUnequip(this);
            }
        }
    }

    void LockInventory()
    {
        for (int i = 0; i < inventory.Count; i++)
        {
            inventory[i].locked = status.Value == AgentStatusEnum.Active;
        }
    }
}




