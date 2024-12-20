using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "NewSongChannel", menuName = "ScriptableObjects/Channels/Song", order = 1)]
public class SongChannel : ScriptableObject
{
    private List<ISongChannelListener> listeners = new List<ISongChannelListener>();

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

    public void RegisterListener(ISongChannelListener listener)
    {
        listeners.Add(listener);
    }

    public void UnregistarListener(ISongChannelListener listener)
    {
        listeners.Remove(listener);
    }
}
