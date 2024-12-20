using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "NewFloatChannel", menuName = "ScriptableObjects/Channels/Float", order = 1)]
public class FloatChannel : ScriptableObject
{
    private List<IFloatChannelListener> listeners = new List<IFloatChannelListener>();

    public void Raise(float value)
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

    public void RegisterListener(IFloatChannelListener listener)
    {
        listeners.Add(listener);
    }

    public void UnregistarListener(IFloatChannelListener listener)
    {
        listeners.Remove(listener);
    }
}
