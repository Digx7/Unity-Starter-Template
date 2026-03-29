using UnityEngine;
using UnityEngine.Events;

namespace Digx7.Zygote
{
    public class QuestDataChannelRaiser : MonoBehaviour
    {
        [SerializeField] private QuestDataChannel channelToRaise;
        [SerializeField] private QuestData m_data;

        public void Raise(QuestData data)
        {
            channelToRaise.Raise(data);
        }

        public void Raise()
        {
            channelToRaise.Raise(m_data);
        }
    }
}
