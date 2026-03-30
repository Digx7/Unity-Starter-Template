using UnityEngine;
using UnityEngine.Events;

namespace Digx7.Zygote
{
    public class ConversationNodeChannelRaiser : MonoBehaviour
    {
        [SerializeField] private ConversationNodeChannel channelToRaise;
        [SerializeField] private ConversationNode _data;

        public void Raise(ConversationNode data)
        {
            channelToRaise.Raise(data);
        }

        public void Raise()
        {
            channelToRaise.Raise(_data);
        }
    }
}
