using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AgentStat
{
    IntegerVariable _value = new IntegerVariable();

    int _baseValue;
    List<UnityAction<IntegerVariable>> Modifiers = new List<UnityAction<IntegerVariable>>();
    bool _dirty;
    
    public int Value
    {
        get
        {
            if (_dirty)
            {
                _dirty = false; 
                _value.Value = _baseValue;
                Modifiers.ForEach(mod => mod(_value));
            }
            return _value.Value;
        }
    }
    
    public AgentStat(int value)
    {
        _value.Value = value;
    }

    public void AddModifier(UnityAction<IntegerVariable> mod)
    {
        Modifiers.Add(mod);
        _dirty = true;
    }

    public void RemoveModifier(UnityAction<IntegerVariable> mod)
    {
        Modifiers.Remove(mod);
        _dirty = true;
    }
}

public class IntegerVariable : ObservedVariable<int> { }