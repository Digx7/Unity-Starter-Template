using UnityEngine;
using UnityEngine.Events;

namespace Digx7.Zygote
{
    public class QuestObjectiveChannelRaiser : MonoBehaviour
    {
        [SerializeField] private QuestObjectiveChannel channelToRaise;
        [SerializeField] private QuestObjective m_data;

        public void Raise(QuestObjective data)
        {
            channelToRaise.Raise(data);
        }

        public void Raise()
        {
            channelToRaise.Raise(m_data);
        }
    }
}
