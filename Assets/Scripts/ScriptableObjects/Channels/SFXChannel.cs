using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "NewSFXChannel", menuName = "ScriptableObjects/Channels/SFX", order = 1)]
public class SFXChannel : ScriptableObject
{
    private List<ISFXChannelListener> listeners = new List<ISFXChannelListener>();

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

    public void RegisterListener(ISFXChannelListener listener)
    {
        listeners.Add(listener);
    }

    public void UnregistarListener(ISFXChannelListener listener)
    {
        listeners.Remove(listener);
    }
}
