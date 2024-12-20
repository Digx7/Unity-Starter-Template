using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "NewBooleanChannel", menuName = "ScriptableObjects/Channels/Boolean", order = 1)]
public class BooleanChannel : ScriptableObject
{
    private List<IBooleanChannelListener> listeners = new List<IBooleanChannelListener>();

    public void Raise(bool value)
    {
        for (int i = 0; i < listeners.Count; i++)
        {
            listeners[i].OnEventRaised(value);
        }

        if (listeners.Count == 0)
        {
            Debug.LogWarning("A channel was called that has no listeners");
        }
    }

    public void RegisterListener(IBooleanChannelListener listener)
    {
        listeners.Add(listener);
    }

    public void UnregistarListener(IBooleanChannelListener listener)
    {
        listeners.Remove(listener);
    }
}
