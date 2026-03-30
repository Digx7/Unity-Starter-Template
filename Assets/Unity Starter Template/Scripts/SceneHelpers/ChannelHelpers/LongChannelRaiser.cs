using UnityEngine;
using UnityEngine.Events;

namespace Digx7.Zygote
{
    public class LongChannelRaiser : MonoBehaviour
    {
        [SerializeField] private LongChannel channelToRaise;
        [SerializeField] private long m_data;

        public void Raise(long data)
        {
            channelToRaise.Raise(data);
        }

        public void Raise()
        {
            channelToRaise.Raise(m_data);
        }
    }
}
