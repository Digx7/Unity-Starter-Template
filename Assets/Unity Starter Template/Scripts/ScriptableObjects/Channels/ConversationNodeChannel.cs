using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "NewFloatChannel", menuName = "ScriptableObjects/Channels/Float", order = 1)]
public class ConversationNodeChannel : ScriptableObject
{

    public ConversationNodeEvent channelEvent = new FloatEvent();

    public void Raise(ConversationNode value)
    {
        channelEvent.Invoke(value);
    }

    
}