using UnityEngine;
using UnityEngine.Events;

namespace Digx7.Zygote
{
    public class QuestObjectiveTypeChannelRaiser : MonoBehaviour
    {
        [SerializeField] private QuestObjectiveTypeChannel channelToRaise;
        [SerializeField] private QuestObjectiveType _data;

        public void Raise(QuestObjectiveType data)
        {
            channelToRaise.Raise(data);
        }

        public void Raise()
        {
            channelToRaise.Raise(_data);
        }
    }
}
