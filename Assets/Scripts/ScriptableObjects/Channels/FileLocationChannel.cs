using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "NewFileLocationChannel", menuName = "ScriptableObjects/Channels/FileLocation", order = 1)]
public class FileLocationChannel : ScriptableObject
{
    private List<IFileLocationChannelListener> listeners = new List<IFileLocationChannelListener>();

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

    public void RegisterListener(IFileLocationChannelListener listener)
    {
        listeners.Add(listener);
    }

    public void UnregistarListener(IFileLocationChannelListener listener)
    {
        listeners.Remove(listener);
    }
}
