using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "NewChannel", menuName = "ScriptableObjects/Channels/Default", order = 1)]
public class Channel : ScriptableObject
{
    private List<IChannelListener> listeners = new List<IChannelListener>();

    public void Raise()
    {
        for (int i = 0; i < listeners.Count; i++)
        {
            listeners[i].OnEventRaised();
        }

        if (listeners.Count == 0)
        {
            Debug.LogWarning("A channel was called that has no listeners");
        }
    }

    public void RegisterListener(IChannelListener listener)
    {
        listeners.Add(listener);
    }

    public void UnregistarListener(IChannelListener listener)
    {
        listeners.Remove(listener);
    }
}
