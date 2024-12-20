using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "NewVector2Channel", menuName = "ScriptableObjects/Channels/Vector2", order = 1)]
public class Vector2Channel : ScriptableObject
{
    private List<IVector2ChannelListener> listeners = new List<IVector2ChannelListener>();

    public void Raise(Vector2 value)
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

    public void RegisterListener(IVector2ChannelListener listener)
    {
        listeners.Add(listener);
    }

    public void UnregistarListener(IVector2ChannelListener listener)
    {
        listeners.Remove(listener);
    }
}
