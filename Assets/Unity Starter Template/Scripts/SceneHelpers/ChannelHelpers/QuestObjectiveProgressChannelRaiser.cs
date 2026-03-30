using UnityEngine;
using UnityEngine.Events;

namespace Digx7.Zygote
{
    public class QuestObjectiveProgressChannelRaiser : MonoBehaviour
    {
        [SerializeField] private QuestObjectiveProgressChannel channelToRaise;
        [SerializeField] private QuestObjectiveProgress _data;

        public void Raise(QuestObjectiveProgress data)
        {
            channelToRaise.Raise(data);
        }

        public void Raise()
        {
            channelToRaise.Raise(_data);
        }
    }
}
