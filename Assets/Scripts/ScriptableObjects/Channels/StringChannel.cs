using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "NewStringChannel", menuName = "ScriptableObjects/Channels/String", order = 1)]
public class StringChannel : ScriptableObject
{
    private List<IStringChannelListener> listeners = new List<IStringChannelListener>();

    public void Raise(string value)
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

    public void RegisterListener(IStringChannelListener listener)
    {
        listeners.Add(listener);
    }

    public void UnregistarListener(IStringChannelListener listener)
    {
        listeners.Remove(listener);
    }
}
