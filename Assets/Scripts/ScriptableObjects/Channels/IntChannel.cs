using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "NewIntChannel", menuName = "ScriptableObjects/Channels/Int", order = 1)]
public class IntChannel : ScriptableObject
{
    private List<IIntChannelListener> listeners = new List<IIntChannelListener>();

    public void Raise(int value)
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

    public void RegisterListener(IIntChannelListener listener)
    {
        listeners.Add(listener);
    }

    public void UnregistarListener(IIntChannelListener listener)
    {
        listeners.Remove(listener);
    }
}
