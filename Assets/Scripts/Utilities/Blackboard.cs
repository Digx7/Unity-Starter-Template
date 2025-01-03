using UnityEngine;
using UnityEngine.Events;
using System;
using System.Collections;
using System.Collections.Generic;

public class Blackboard : MonoBehaviour
{
    private Dictionary<string, GenericBlackBoardEntry> entries;

    public T GetData<T>(string key)
    {
        if(!entries.ContainsKey(key))
        {
            CreateDefaultEntry<T>(key);
        }

        return entries[key].GetEntryValue<T>();
    }

    public void UpdateData<T>(string key, T value)
    {
        if(!entries.ContainsKey(key))
        {
            CreateDefaultEntry<T>(key);
        }
        
        entries[key].SetEntryValue<T>(value);
    }

    public void SubscribeToUpdates(string key, UnityAction<object, System.Type> call)
    {
        if(!entries.ContainsKey(key))
        {
            CreateDefaultEntry<object>(key);
        }

        entries[key].OnEntryChanged.AddListener(call);
    }

    public void UnSubscribeToUpdates(string key, UnityAction<object, System.Type> call)
    {
        if(!entries.ContainsKey(key))
        {
            CreateDefaultEntry<object>(key);
        }

        entries[key].OnEntryChanged.RemoveListener(call);
    }

    private void CreateDefaultEntry<T>(string key)
    {
        entries[key] = new GenericBlackBoardEntry(typeof(T));
    }
}