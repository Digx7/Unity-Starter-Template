using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "NewSceneChannel", menuName = "ScriptableObjects/Channels/Scene", order = 1)]
public class SceneChannel : ScriptableObject
{
    private List<ISceneChannelListener> listeners = new List<ISceneChannelListener>();

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

    public void RegisterListener(ISceneChannelListener listener)
    {
        listeners.Add(listener);
    }

    public void UnregistarListener(ISceneChannelListener listener)
    {
        listeners.Remove(listener);
    }
}
