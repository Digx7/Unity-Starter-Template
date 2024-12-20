using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "NewVector3Channel", menuName = "ScriptableObjects/Channels/Vector3", order = 1)]
public class Vector3Channel : ScriptableObject
{
    private List<IVector3ChannelListener> listeners = new List<IVector3ChannelListener>();

    public void Raise(Vector3 value)
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

    public void RegisterListener(IVector3ChannelListener listener)
    {
        listeners.Add(listener);
    }

    public void UnregistarListener(IVector3ChannelListener listener)
    {
        listeners.Remove(listener);
    }
}
