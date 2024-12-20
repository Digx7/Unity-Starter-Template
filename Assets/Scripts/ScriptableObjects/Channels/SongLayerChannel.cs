using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "NewSongLayerChannel", menuName = "ScriptableObjects/Channels/SongLayer", order = 1)]
public class SongLayerChannel : ScriptableObject
{
    private List<ISongLayerChannelListener> listeners = new List<ISongLayerChannelListener>();

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

    public void RegisterListener(ISongLayerChannelListener listener)
    {
        listeners.Add(listener);
    }

    public void UnregistarListener(ISongLayerChannelListener listener)
    {
        listeners.Remove(listener);
    }
}
