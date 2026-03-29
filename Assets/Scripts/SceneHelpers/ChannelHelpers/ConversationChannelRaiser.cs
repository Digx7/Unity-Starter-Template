using UnityEngine;
using UnityEngine.Events;

namespace Digx7.Zygote
{
    public class ConversationChannelRaiser : MonoBehaviour
    {
        [SerializeField] private ConversationChannel channelToRaise;
        [SerializeField] private Conversation m_data;

        public void Raise(Conversation data)
        {
            channelToRaise.Raise(data);
        }

        public void Raise()
        {
            channelToRaise.Raise(m_data);
        }
    }
}
