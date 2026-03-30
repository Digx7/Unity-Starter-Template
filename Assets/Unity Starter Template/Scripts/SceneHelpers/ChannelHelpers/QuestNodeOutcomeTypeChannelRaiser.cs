using UnityEngine;
using UnityEngine.Events;

namespace Digx7.Zygote
{
    public class QuestNodeOutcomeTypeChannelRaiser : MonoBehaviour
    {
        [SerializeField] private QuestNodeOutcomeTypeChannel channelToRaise;
        [SerializeField] private QuestNodeOutcomeType _data;

        public void Raise(QuestNodeOutcomeType data)
        {
            channelToRaise.Raise(data);
        }

        public void Raise()
        {
            channelToRaise.Raise(_data);
        }
    }
}
