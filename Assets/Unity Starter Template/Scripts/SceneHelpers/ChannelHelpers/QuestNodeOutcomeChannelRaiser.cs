using UnityEngine;
using UnityEngine.Events;

namespace Digx7.Zygote
{
    public class QuestNodeOutcomeChannelRaiser : MonoBehaviour
    {
        [SerializeField] private QuestNodeOutcomeChannel channelToRaise;
        [SerializeField] private QuestNodeOutcome _data;

        public void Raise(QuestNodeOutcome data)
        {
            channelToRaise.Raise(data);
        }

        public void Raise()
        {
            channelToRaise.Raise(_data);
        }
    }
}
