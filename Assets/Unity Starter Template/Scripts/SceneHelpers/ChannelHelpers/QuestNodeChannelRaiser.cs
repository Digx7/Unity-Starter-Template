using UnityEngine;
using UnityEngine.Events;

namespace Digx7.Zygote
{
    public class QuestNodeChannelRaiser : MonoBehaviour
    {
        [SerializeField] private QuestNodeChannel channelToRaise;
        [SerializeField] private QuestNode m_data;

        public void Raise(QuestNode data)
        {
            channelToRaise.Raise(data);
        }

        public void Raise()
        {
            channelToRaise.Raise(m_data);
        }
    }
}
