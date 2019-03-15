using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObservedList<T>
{
    [SerializeField]
    List<T> _value;

    public int Count { get { return _value.Count; } }

    public T this[int i] { get { return _value[i]; } set { _preChange.Invoke();  _value[i] = value; _onChange.Invoke(); } }

    [NonSerialized]
    UnityEvent _onChange = new UnityEvent();

    public void RegisterAction(UnityAction action)
    {
        _onChange.AddListener(action);
    }

    public void UnregisterAction(UnityAction action)
    {
        _onChange.RemoveListener(action);
    }

    public void Invoke()
    {
        _onChange.Invoke();
    }

    public void Add(T item)
    {
        _preChange.Invoke();
        _value.Add(item);
        _onChange.Invoke();
    }

    public void Remove(T item)
    {
        _preChange.Invoke();
        _value.Remove(item);
        _onChange.Invoke();
    }
    
    public bool Contains(T item)
    {
        return _value.Contains(item);
    }

    [NonSerialized]
    UnityEvent _preChange = new UnityEvent();

    public void RegisterPreAction(UnityAction action)
    {
        _preChange.AddListener(action);
    }

    public void UnregisterPreAction(UnityAction action)
    {
        _preChange.RemoveListener(action);
    }

    public void InvokePre()
    {
        _preChange.Invoke();
    }
}
